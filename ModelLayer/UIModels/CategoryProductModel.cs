using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.UIModels
{
    public class CategoryProductModel : IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long ProductId { get; set; }
        public long CreatedBy { get; set; }

        [Required]
        public string ArticleNumber { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryId <= 0)
            {
                yield return new ValidationResult("CategoryId not valid");
            }
            if (ProductId <= 0)
            {
                yield return new ValidationResult("ProductId not valid");
            }

            if (string.IsNullOrEmpty(ArticleNumber))
            {
                yield return new ValidationResult("ArticleNumber not valid");
            }

            if (UnitPrice <= 0)
            {
                yield return new ValidationResult("UnitPrice not valid");
            }
        }
    }
}
