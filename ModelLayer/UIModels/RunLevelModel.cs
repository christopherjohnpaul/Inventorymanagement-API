using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class RunLevelModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public int RunNumber { get; set; }
        [Required]
        public long DriverId { get; set; }
        [Required]
        public long OrderProductId { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RunNumber <= 0)
            {
                yield return new ValidationResult("RunNumber not valid");
            }
            if (DriverId <= 0)
            {
                yield return new ValidationResult("DriverId not valid");
            }
            if (OrderProductId <= 0)
            {
                yield return new ValidationResult("OrderProductId not valid");
            }
        }
    }
}
