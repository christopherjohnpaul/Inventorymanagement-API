using ModelLayer.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class ContactModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string MobileNumber { get; set; }
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public long LocationId { get; set; }
        public long ContactTypeId { get; set; }
        public long CreatedBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                yield return new ValidationResult("FirstName not valid");
            }
        }
    }
}
