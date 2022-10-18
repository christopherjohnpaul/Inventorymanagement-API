using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class GoogleLoginModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email required");
            }

        }
    }
}
