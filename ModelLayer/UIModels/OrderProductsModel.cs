using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class OrderProductsModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long OrderId { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long SupplierId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int SalesDay { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        [Required]
        public int SequenceNumber { get; set; }
        [Required]
        public long StoreId { get; set; }
        [Required]
        public long TemplateId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderId <= 0)
            {
                yield return new ValidationResult("OrderId not valid");
            }
            if (ProductId <= 0)
            {
                yield return new ValidationResult("ProductId not valid");
            }
            if (Quantity <= 0)
            {
                yield return new ValidationResult("Quantity not valid");
            }
            if (SalesDay <= 0)
            {
                yield return new ValidationResult("SalesDay not valid");
            } 
            if (SequenceNumber <= 0)
            {
                yield return new ValidationResult("SequenceNumber not valid");
            }
            if (StoreId <= 0)
            {
                yield return new ValidationResult("StoreId not valid");
            }
            if (SupplierId <= 0)
            {
                yield return new ValidationResult("SupplierId not valid");
            }
        }
    }
}

