using System.ComponentModel.DataAnnotations;

namespace InventoryManagementWebApi.Models
{
    public class ContactModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string MobileNumber { get; set; }
        [Required]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(60)]
        public int LocationId { get; set; }
    }
}
