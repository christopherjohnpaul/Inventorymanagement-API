using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class StoreGroupDriverMappingModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string GroupeName { get; set; }
        [Required]
        public long DriverId { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(GroupeName))
            {
                yield return new ValidationResult("GroupeName not valid");
            }
            if (DriverId <= 0)
            {
                yield return new ValidationResult("DriverId not valid");
            }
        }
    }
}
