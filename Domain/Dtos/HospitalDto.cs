using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using MedicineProject.HospitalService.Domain.Dtos.Base;

namespace MedicineProject.HospitalService.Domain.Dtos
{
    public record HospitalDto : BaseDto
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("started_time")]
        public TimeOnly StartedTime { get; set; }

        [Required]
        [JsonPropertyName("end_time")]
        public TimeOnly EndTime { get; set; }

        [Required]
        [JsonPropertyName("contects")]
        public string Contacts { get; set; }

        [JsonPropertyName("rating")]
        public byte Rating { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("city_id")]
        public long CityId { get; set; }

        public HospitalDto() { }
    }
}
