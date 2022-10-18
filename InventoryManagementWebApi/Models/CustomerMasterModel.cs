using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class CustomerMasterModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        //[MaxLength(50)]
        public int CustomerTypeId { get; set; }
        [Required]
        public bool IndividualPrice { get; set; }
        [Required]
        [MaxLength(100)]
        public string PirceLevel { get; set; }
    }
}
