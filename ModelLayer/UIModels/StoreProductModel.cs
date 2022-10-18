using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class StoreProductModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public string ArticleNumber { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long StoreId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(300)]
        public string Group { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ArticleNumber))
            {
                yield return new ValidationResult("ArticleNumber not valid");
            }
            if (ProductId <= 0)
            {
                yield return new ValidationResult("ProductId not valid");
            }
        }
    }
}
