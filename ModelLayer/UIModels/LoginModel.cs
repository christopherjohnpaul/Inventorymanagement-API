using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class LoginModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email required");
            }
            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password required");
            }
        }
    }
}
