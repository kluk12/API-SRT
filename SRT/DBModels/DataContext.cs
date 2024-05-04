using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SRT.DBModels
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<ApplicationDbContext>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Config> Configs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<LocationDictionary> LocationDictionary { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
  
        
        
        
        

        //dotnet ef migrations add Name --project SRT
        // dotnet ef database update --project SRT
    }
}
