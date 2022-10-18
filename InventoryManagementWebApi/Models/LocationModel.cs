using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class LocationModel 
    {
        [Required]
        [MaxLength(100)]
        public string Suburb { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; }
        [Required]
        [MaxLength(100)]
        public string Latitude { get; set; }
        [Required]
        [MaxLength(100)]
        public string Longitude { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string PostalCode { get; set; }
    }
}
