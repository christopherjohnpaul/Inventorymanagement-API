using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class StoreInfoModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public long ContactId { get; set; }
        [Required]
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Code))
            {
                yield return new ValidationResult("Code not valid");
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }
            if (ContactId <= 0)
            {
                yield return new ValidationResult("ContactId not valid");
            }
        }
    }
}
