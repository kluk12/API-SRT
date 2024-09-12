using MediatR;
using Microsoft.EntityFrameworkCore;
using SRT.DBModels;
using SRT.DBModels.Interface;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRT.Commands
{
    public class FindTrainingCommand : IRequest<FindTrainingsDto>
    {
    }

    public class FindTrainingCommandHandler : IRequestHandler<FindTrainingCommand, FindTrainingsDto>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public FindTrainingCommandHandler(ITrainingRepository trainingRepository)
        {
            _TrainingRepository = trainingRepository;
        }

        public async Task<FindTrainingsDto> Handle(FindTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var startOfWeek = StartOfWeek(DateTime.Now, DayOfWeek.Monday);
                var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                var currentWeekItems = await _TrainingRepository.Find().Include(x => x.Reservations)
                    .Where(x => x.DateFrom.HasValue && x.DateTo.HasValue &&
                                x.DateFrom.Value >= startOfWeek && x.DateTo.Value <= endOfWeek)
                    .ToListAsync();

                var nextWeekStart = endOfWeek.AddSeconds(1);
                var nextWeekEnd = nextWeekStart.AddDays(7).AddSeconds(-1);

                var nextWeekItems = await _TrainingRepository.Find()
                    .Where(x => x.DateFrom.HasValue && x.DateTo.HasValue &&
                                x.DateFrom.Value >= nextWeekStart && x.DateTo.Value <= nextWeekEnd)
                    .ToListAsync();

                var currentWeekHours = GroupTrainingsByHourAndDay(currentWeekItems);
                var nextWeekHours = GroupTrainingsByHourAndDay(nextWeekItems);

                return new FindTrainingsDto
                {
                    CurrentWeekItems = currentWeekHours,
                    NextWeekItems = nextWeekHours
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<HourlyActivities> GroupTrainingsByHourAndDay(List<Training> trainings)
        {
            // Grupowanie treningów po godzinie i dniu tygodnia
            var groupedActivities = trainings
                .Where(x => x.DateFrom.HasValue)
                .GroupBy(x => new
                {
                    Hour = x.DateFrom.Value.Hour,
                    DayOfWeek = x.DateFrom.Value.DayOfWeek
                })
                .ToDictionary(g => new { g.Key.Hour, g.Key.DayOfWeek }, g => g.ToList());

            // Generowanie pełnych przedziałów czasowych od 6:00 do 20:00 dla każdego dnia tygodnia
            var hours = Enumerable.Range(6, 14)
                .Select(hour => new HourlyActivities
                {
                    Time = $"{hour}:00 - {hour + 1}:00",
                    Activities = Enumerable.Range(0, 7)
                        .Select(dayIndex =>
                        {
                            var dayOfWeek = (DayOfWeek)dayIndex;
                            return groupedActivities.TryGetValue(new { Hour = hour, DayOfWeek = dayOfWeek }, out var activities)
                                ? activities.FirstOrDefault()  // We assume one activity per hour per day; if multiple, handle accordingly
                                : null;
                        })
                        .ToList()
                })
                .Where(h => h.Activities.Any(a => a != null)) 
                .ToList();

            return hours;
        }

        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

    public class FindTrainingsDto
    {
        public List<HourlyActivities> CurrentWeekItems { get; set; }
        public List<HourlyActivities> NextWeekItems { get; set; }
    }

    public class HourlyActivities
    {
        public string Time { get; set; }
        public List<Training?> Activities { get; set; } = new List<Training?>();
    }
}
