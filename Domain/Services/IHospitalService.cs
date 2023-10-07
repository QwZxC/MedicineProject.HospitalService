using MedicineProject.HospitalService.Domain.Dtos;
using MedicineProject.HospitalService.Domain.Filters;
using MedicineProject.HospitalService.Domain.Models;

namespace MedicineProject.HospitalService.Domain.Services
{
    public interface IHospitalService
    {
        /// <summary>
        /// Осуществляет поиск списка больниц по подходящим по Get-параметрам.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter);

        /// <summary>
        /// Осуществляет поиск больницы по её id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hospital> GetHospitalByIdAsync(long id);

        /// <summary>
        /// Добавляет запись больницы в бд.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<HospitalDto> AddHospitalAsync(HospitalDto dto);

        /// <summary>
        /// Обнавляет запись больницы в бд.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hospital"></param>
        /// <returns></returns>
        Task<HospitalDto> UpdateHospitalAsync(HospitalDto dto, Hospital hospital);

        /// <summary>
        /// Осуществляет поиск больницы по её названию.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Hospital> GetHospitalByNameAsync(string name);
        
        /// <summary>
        /// Производит маппинг из одного типа в другой. Возвращает преобразованный объект.
        /// </summary>
        /// <typeparam name="TOriginal"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="hospital"></param>
        /// <returns></returns>
        TTarget MapHospital<TOriginal, TTarget>(TOriginal hospital);
    }
}
