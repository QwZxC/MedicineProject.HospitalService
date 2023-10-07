using AutoMapper;
using MedicineProject.HospitalService.Domain.Dtos;
using MedicineProject.HospitalService.Domain.Models;

namespace MedicineProject.HospitalService.Domain.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Hospital, HospitalDto>().ReverseMap();
        }
    }
}
