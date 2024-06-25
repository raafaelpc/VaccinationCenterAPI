using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VaccinationCenters.Models
{
    public class VaccinationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vaccine> Vaccines { get; set; }

    }
}
