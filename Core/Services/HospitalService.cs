using AutoMapper;
using MedicineProject.HospitalService.Domain.Dtos;
using MedicineProject.HospitalService.Domain.Filters;
using MedicineProject.HospitalService.Domain.Models;
using MedicineProject.HospitalService.Domain.Repositories;
using MedicineProject.HospitalService.Domain.Services;

namespace MedicineProject.HospitalService.Core.Services
{
    /// <summary>
    /// Сервис для работы с больницами.
    /// </summary>
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repository;
        private readonly IMapper _mapper;

        public HospitalService(IHospitalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HospitalDto> AddHospitalAsync(HospitalDto dto)
        {
            Hospital hospital = MapHospital<HospitalDto, Hospital>(dto);
            await _repository.CreateItemAsync(hospital);
            dto.Id = hospital.Id;
            return dto;
        }

        public async Task<Hospital> GetHospitalByNameAsync(string name)
        {
            return await _repository.TryGetItemByNameAsync<Hospital>(name);
        }

        public async Task<Hospital> GetHospitalByIdAsync(long id)
        {
            Hospital hospital = await _repository.TryGetItemByIdAsync<Hospital>(id);
            if (hospital == null)
            {
                return null;
            }
            
            return hospital;
        }

        public async Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter)
        {
            List<Hospital> dbHospitals = await _repository.GetItemListAsync<Hospital>();
            List<Hospital> hospitals = new List<Hospital>();
            dbHospitals.ForEach(hospital =>
            {
                if (hospital.Name.Contains(filter.Name) &&
                    hospital.CityId == filter.CityId &&
                    hospital.Rating >= filter.MinRating &&
                    hospital.Rating <= filter.MaxRating)
                {
                    hospitals.Add(hospital);
                }
            });
            return hospitals;
        }

        public async Task<HospitalDto> UpdateHospitalAsync(HospitalDto dto, Hospital hospital)
        {
            hospital.Name = dto.Name;
            hospital.Description = dto.Description;
            hospital.StartedTime = dto.StartedTime;
            hospital.EndTime = dto.EndTime;
            hospital.CityId = dto.CityId;
            hospital.Rating = dto.Rating;
            hospital.Address = dto.Address;
            await _repository.UpdateItemAsync(MapHospital<HospitalDto, Hospital>(dto),hospital);
            return dto;
        }

        public TTarget MapHospital<TOriginal, TTarget>(TOriginal hospital)
        {
            return _mapper.Map<TTarget>(hospital);
        }
    }
}
