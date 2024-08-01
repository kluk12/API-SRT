using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SRT.DBModels;
using SRT.DBModels.Interface;
using SRT.DBModels.Repos;
using System;
public class Program {
    public static void Main(string[] args)
    { 
        var builder = WebApplication.CreateBuilder(args);
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    //   builder.Services.AddCors(options =>
    //   {
    //       options.AddPolicy(name: MyAllowSpecificOrigins,
    //                         policy =>
    //                         {
    //                             policy.WithOrigins("http://localhost:4200"
    //                                                ).AllowAnyMethod()
    //.AllowCredentials()
    //.AllowAnyHeader();
    //                         });
    //   });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var connectionString = builder.Configuration.GetConnectionString("SRTConnectionString");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

        });
        builder.Services.AddTransient(typeof(IConfigRepository), typeof(ConfigRepository));
        builder.Services.AddTransient(typeof(ILocationDictionaryRepository), typeof(LocationDictionaryRepository));
        builder.Services.AddTransient(typeof(IReservationRepository), typeof(ReservationRepository));
        builder.Services.AddTransient(typeof(ITrainingRepository), typeof(TrainingRepository));
        builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        builder.Services.AddControllers();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(c => c.WithOrigins(new string[] { "http://localhost:4200" })
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyHeader());
      //  app.UseCors(MyAllowSpecificOrigins);

        app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}