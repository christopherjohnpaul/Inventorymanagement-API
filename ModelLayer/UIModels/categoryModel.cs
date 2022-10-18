using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class CategoryModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public long CreatedBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }
        }
    }
}
