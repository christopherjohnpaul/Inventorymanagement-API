using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class StoreGroupStoreMappingModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long StoreGroupId { get; set; }
        [Required]
        public long StoreId { get; set; }

        public long CreatedBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StoreGroupId <= 0)
            {
                yield return new ValidationResult("StoreGroupId not valid");
            }
            if (StoreId <= 0)
            {
                yield return new ValidationResult("StoreId not valid");
            }
        }
    }
}
