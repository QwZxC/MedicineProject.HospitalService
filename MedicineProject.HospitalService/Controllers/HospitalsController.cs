using AutoMapper;
using MedicineProject.HospitalService.Domain.Context;
using MedicineProject.HospitalService.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MedicineProject.HospitalService.Domain.Models;
using MedicineProject.HospitalService.Domain.Dtos;
using MedicineProject.HospitalService.Domain.Services;

namespace MedicineProject.Controllers
{
    [ApiController]
    [Route("api/hospitals")]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _service;

        public HospitalsController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache, IHospitalService service) 
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<HospitalDto>>> GetAllHospitals([FromQuery] HospitalFilter filter)
        {
            List<Hospital> hospitals = await _service.GetHospitalsWithFilterAsync(filter);
            List<HospitalDto> hospitalsDTOs = new List<HospitalDto>();

            hospitals.ForEach(hospital => 
            {
                HospitalDto hospitalDTO = _service.MapHospital<Hospital, HospitalDto>(hospital);
                hospitalsDTOs.Add(hospitalDTO);
            });

            return Ok(hospitalsDTOs);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDto>> GetHospital([FromRoute] long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Hospital targetHospital = await _service.GetHospitalByIdAsync(id);

            if (targetHospital == null)
            {
                return NotFound("Такой больницы нет в списке");
            }

            HospitalDto hospitalDTO = _service.MapHospital<Hospital, HospitalDto>(targetHospital);

            return Ok(hospitalDTO);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDto>> AddHospital([FromBody] HospitalDto hospitalDTO)
        {
            if (hospitalDTO == null) 
            {
                return BadRequest();
            }

            if (await _service.GetHospitalByNameAsync(hospitalDTO.Name) != null)
            {
                return BadRequest("Больница с таким названием уже есть в списке");
            }

            await _service.AddHospitalAsync(hospitalDTO);

            return Ok(hospitalDTO);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDto>> UpdateHospital([FromBody] HospitalDto hospitalDTO)
        {
            if (hospitalDTO == null)
            {
                return BadRequest();
            }
            Hospital oldHospital = await _service.GetHospitalByIdAsync(hospitalDTO.Id);

            if (oldHospital == null)
            {
                return NotFound("Такой больницы нет.");
            }

            await _service.UpdateHospitalAsync(hospitalDTO, oldHospital);

            return Ok(hospitalDTO);
        }
    }
}
