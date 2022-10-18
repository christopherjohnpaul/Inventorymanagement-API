using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
