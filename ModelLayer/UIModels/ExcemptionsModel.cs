using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class ExcemptionsModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long OrderTemplateId { get; set; }
        [Required]
        public double MultiplyOders { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderTemplateId <= 0)
            {
                yield return new ValidationResult("OrderTemplateId not valid");
            }
            //if (MultiplyOders == 0)
            //{
            //    yield return new ValidationResult("MultiplyOders not valid");
            //}
            if (FromDate == default)
            {
                yield return new ValidationResult("FromDate not valid");
            }
            if (ToDate == default)
            {
                yield return new ValidationResult("ToDate not valid");
            }
        }
    }
}
