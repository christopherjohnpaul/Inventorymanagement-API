using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class ProductSupplierUnitPriceModel: IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long SupplierId { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime EffectiveFromDate { get; set; }
        public DateTime? EffectiveTillDate { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProductId<=0)
            {
                yield return new ValidationResult("ProductId not valid");
            }
            if (SupplierId <= 0)
            {
                yield return new ValidationResult("SupplierId not valid");
            }
            if (UnitPrice <= 0)
            {
                yield return new ValidationResult("UnitPrice not valid");
            }
        }
    }
}
