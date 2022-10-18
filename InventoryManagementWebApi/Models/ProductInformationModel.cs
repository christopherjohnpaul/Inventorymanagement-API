using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class ProductInformationModel
    {
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int QuantityPerCrate { get; set; }
    }
}
