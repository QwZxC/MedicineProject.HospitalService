using System.Text.Json.Serialization;

namespace MedicineProject.HospitalService.Domain.Dtos.Base
{
    public record BaseDto 
    {
        [JsonPropertyName("id")]    
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
