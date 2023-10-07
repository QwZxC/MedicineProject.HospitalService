using MedicineProject.HospitalService.Domain.Context;
using MedicineProject.HospitalService.Domain.Repositories;
using MedicineProject.HospitalService.Domain.Services;
using MedicineProject.HospitalService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.HospitalService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebMobileContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
            builder.Services.AddScoped<IHospitalService, Core.Services.HospitalService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

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