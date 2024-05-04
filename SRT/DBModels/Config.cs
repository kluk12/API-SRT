using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;
using System.Runtime.CompilerServices;

namespace SRT.DBModels
{
    public class Config 
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; } = 0;
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public int? BeforStartTimeInHour { get; set; }
        public int? Summary { get; set; }
        [Precision(18, 2)]
        public decimal FixedCosts { get; set; } = 0;
        public int? WhenCloseTraining { get; set; }

    }  
    public class User 
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModuficationDate { get; set; }
        public int? Phone { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Login { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
        public bool IsDeleted { get; set; }= false;


    }
}
