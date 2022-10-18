using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class OrderTemplateModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long RegionId { get; set; }
        [Required]
        public long DriverId { get; set; }
        [Required]
        [MaxLength(2)]
        public string TimeOfDelivery { get; set; }
        public bool DeactivateExcemptions { get; set; }
        public int DayOfWeek { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }
            if (RegionId <= 0)
            {
                yield return new ValidationResult("Region not valid");
            }
            if (DriverId <= 0)
            {
                yield return new ValidationResult("DriverId not valid");
            }
            if (string.IsNullOrEmpty(TimeOfDelivery))
            {
                yield return new ValidationResult("TimeOfDelivery not valid");
            }
        }
    }
}
