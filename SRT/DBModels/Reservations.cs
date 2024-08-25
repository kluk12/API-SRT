using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace SRT.DBModels
{
    public class Reservation
    {
      
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal? Price { get; set; } = 0m;
        public bool?  IsDelete { get; set; }=false;
        public DateTime? Remove { get; set; }
        public DateTime? Create { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? WhenCloseRezerwation { get; set; }
        public int? LocationId { get; set; }
        public int? Type { get; set; }
        public bool? Paid { get; set; }
        public int? TrainingId { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; } 

    }
}
