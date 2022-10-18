using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class OrderModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public DateTime OrderDay { get; set; }
        [Required]
        public long OrderTemplateId { get; set; }
        [Required]
        public long DriverId { get; set; }
        [Required]
        [MaxLength(2)]
        public string TimeOfDelivery { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderDay==default)
            {
                yield return new ValidationResult("OrderDay not valid");
            }
            if (OrderTemplateId <=0)
            {
                yield return new ValidationResult("OrderTemplateId not valid");
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
