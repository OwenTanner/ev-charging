using System.ComponentModel.DataAnnotations;

namespace EvChargingApp.Models
{
    public class ApplicationData
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(255)]
        public string? AddressLine1 { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Postcode { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(15)]
        public string? VehicleRegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
