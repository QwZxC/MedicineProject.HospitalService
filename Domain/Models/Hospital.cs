using MedicineProject.HospitalService.Domain.Models.Base;

namespace MedicineProject.HospitalService.Domain.Models
{
    public class Hospital : BaseModel
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Contacts { get; set; }

        public byte Rating { get; set; }

        public string Email { get; set; }

        public long CityId { get; set; }

        public Hospital() { }
    }
}
