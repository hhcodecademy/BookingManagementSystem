
using BookingManagementSystem.API.Extensions;
using BookingManagementSystem.API.Validation;
using BookingManagementSystem.BLL.MapProfile;
using BookingManagementSystem.BLL.Services;
using BookingManagementSystem.BLL.Services.Interface;
using BookingManagementSystem.DAL.Data;
using BookingManagementSystem.DAL.Repository;
using BookingManagementSystem.DAL.Repository.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using ILogger = Serilog.ILogger;

namespace BookingManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
            builder.Services.AddScoped<IDocumentService, DocumentService>();

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomProfile)));
            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));
            builder.Logging.AddCustomSerilog();
            builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(HotelValidator)));
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
