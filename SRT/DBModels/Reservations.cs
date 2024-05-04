using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace SRT.DBModels
{
    public class Reservation
    {
      
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; } = 0m;
        public DateTime? Remove { get; set; }
        public DateTime? Create { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        public int? NumberPeopleNo { get; set; }
        public int? WhenCloseTraining { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public bool? GeneratorId { get; set; }
        public bool? Paid { get; set; }
        public int? TrainingId { get; set; }

        public Training? Trainings { get; set; } 

    }
}
