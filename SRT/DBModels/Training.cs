using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace SRT.DBModels
{
    public class Training
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; } = 0m;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public int? NumberPeople { get; set; }
        [Precision(18, 2)]
        public decimal FixedCosts { get; set; } = 0m;
        public int? WhenCloseTraining { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? GeneratorId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
    public class TrainingWeek
    {
        public List<Training> CurrentWeekItems { get; set; }
        public List<Training> NextWeekItems { get; set; }
    }
   
}
