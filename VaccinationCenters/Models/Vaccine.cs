using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VaccinationCenters.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Batch { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? VaccinationCenterId { get; set; }
    }
}
