using System.Text.Json.Serialization;

namespace VaccinationCenters.DTOs
{
    public class VaccinationCenterDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
