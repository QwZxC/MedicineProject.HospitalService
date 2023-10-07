using MedicineProject.HospitalService.Domain.Context;
using MedicineProject.HospitalService.Domain.Repositories;

namespace MedicineProject.HospitalService.Infrastructure.Repositories
{
    public class HospitalRepository : BaseRepository, IHospitalRepository
    {
        public HospitalRepository(WebMobileContext context) : base(context) 
        { 
        
        }
    }
}
