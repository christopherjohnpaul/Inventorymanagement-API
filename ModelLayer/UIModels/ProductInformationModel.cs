using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class ProductInformationModel: IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int QuantityPerCrate { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ProductCode))
            {
                yield return new ValidationResult("ProductCode not valid");
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }
            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Description not valid");
            }
        }
    }
}
