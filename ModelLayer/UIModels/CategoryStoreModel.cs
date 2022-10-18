using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class CategoryStoreModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long StoreInfoId { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryId <= 0)
            {
                yield return new ValidationResult("CategoryId not valid");
            }
            if (StoreInfoId <= 0)
            {
                yield return new ValidationResult("StoreInfoId not valid");
            }
        }
    }
}
