using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class CustomerMasterModel: IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        //[MaxLength(50)]
        public int CustomerTypeId { get; set; }
        [Required]
        public bool IndividualPrice { get; set; }
        [Required]
        [MaxLength(100)]
        public string PriceLevel { get; set; }
        [Required]
        public long ContactId { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name not valid");
            }

            if (string.IsNullOrEmpty(PriceLevel))
            {
                yield return new ValidationResult("PirceLevel not valid");
            }
        }
    }
}
