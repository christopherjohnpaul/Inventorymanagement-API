using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class UserInfoModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        //[MaxLength(100)]
        public int UserTypeId { get; set; }

    }
}
