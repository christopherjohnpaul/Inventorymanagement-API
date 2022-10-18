using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class SupplierModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long ContactId { get; set; }
        [Required]
        public bool GenerateOrderEmail { get; set; }
        [Required]
        public bool ApplyException { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }
            if (ContactId <= 0)
            {
                yield return new ValidationResult("Contact id is not valid");
            }
        }
    }
}
