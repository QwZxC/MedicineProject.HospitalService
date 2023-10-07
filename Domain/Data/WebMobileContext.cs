using MedicineProject.HospitalService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.HospitalService.Domain.Context
{
    public sealed class WebMobileContext : DbContext
    {
        public DbSet<Hospital> Hospital { get; set; }

        public WebMobileContext(DbContextOptions<WebMobileContext> options) 
            : base(options) 
        {
        }
    }
}
