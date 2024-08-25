using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;

namespace SRT.Commands
{
    public class FindTrainingCommand : IRequest<TrainingWeek>
    {
        //public int Id { get; set; }
        //public decimal Price { get; set; } = 0;
        //public DateTime? DateTo { get; set; }
        //public DateTime? DateFrom { get; set; }
        //public int? BeforStartTimeInHour { get; set; }
        //public int? Summary { get; set; }
        //public decimal FixedCosts { get; set; } = 0;
        //public int? WhenCloseTraining { get; set; }

    }

    public class FindTrainingCommandHandler : IRequestHandler<FindTrainingCommand, TrainingWeek>
    {
        private readonly ITrainingRepository _TrainingRepository;

        public FindTrainingCommandHandler(ITrainingRepository _trainingRepository)
        {
            _TrainingRepository = _trainingRepository;
        }

        public async Task<TrainingWeek> Handle(FindTrainingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TrainingWeek trainingWeek = new TrainingWeek();
                var startOfWeek = StartOfWeek(DateTime.Now,DayOfWeek.Monday); // Zakładamy, że tydzień zaczyna się w poniedziałek
                var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                var currentWeekItems = await _TrainingRepository.Find()
                    .Where(x => x.DateFrom.HasValue && x.DateTo.HasValue &&
                                x.DateFrom.Value >= startOfWeek && x.DateTo.Value <= endOfWeek)
                    .ToListAsync();

                var startOfNextWeek = startOfWeek.AddDays(7); // Następny tydzień zaczyna się po zakończeniu bieżącego tygodnia
                var endOfNextWeek = startOfNextWeek.AddDays(7).AddSeconds(-1);

                var nextWeekItems = await _TrainingRepository.Find()
                    .Where(x => x.DateFrom.HasValue && x.DateTo.HasValue &&
                                x.DateFrom.Value >= startOfNextWeek && x.DateTo.Value <= endOfNextWeek)
                    .ToListAsync();
                trainingWeek.CurrentWeekItems = currentWeekItems;
                trainingWeek.NextWeekItems = nextWeekItems;
                //todo group by day
                // Grupowanie po godzinie z DateFrom


                // Grupa godzin, do której przypiszemy treningi
                var groupedActivities = currentWeekItems
       .Where(x => x.DateFrom.HasValue) // Pomijamy elementy, gdzie DateFrom jest null
       .GroupBy(x => new
       {
           Hour = x.DateFrom.Value.Hour, // Grupujemy po godzinie
           NextHour = x.DateFrom.Value.Hour + 1 // Dodajemy 1 do godziny dla przedziału godzinowego
       })
       .Select(g => new
       {
           Time = $"{g.Key.Hour}-{g.Key.NextHour}", // Formatowanie przedziału czasowego np. "6-7"
           Activities = g.ToList() // Lista aktywności w danej godzinie
       })
       .Where(g => g.Activities.Any(a => a != null)) // Pomijamy godziny, gdzie wszystkie aktywności są null
       .ToList();



                return trainingWeek;
                //return await _TrainingRepository.Find().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
        public  DateTime StartOfWeek( DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

    }
}
