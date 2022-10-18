using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class LocationModel: IValidatableObject
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Suburb { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; }
        [Required]
        [MaxLength(100)]
        public string Latitude { get; set; }
        [Required]
        [MaxLength(100)]
        public string Longitude { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string PostalCode { get; set; }
        public long CreatedBy { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Suburb))
            {
                yield return new ValidationResult("Suburb not valid");
            }
            if (string.IsNullOrEmpty(State))
            {
                yield return new ValidationResult("State not valid");
            }
            if (string.IsNullOrEmpty(Latitude))
            {
                yield return new ValidationResult("Latitude not valid");
            }
            if (string.IsNullOrEmpty(Longitude))
            {
                yield return new ValidationResult("Longitude not valid");
            }
            if (string.IsNullOrEmpty(AddressLine1))
            {
                yield return new ValidationResult("AddressLine1 not valid");
            }
            if (string.IsNullOrEmpty(AddressLine2))
            {
                yield return new ValidationResult("AddressLine2 not valid");
            }
            if (string.IsNullOrEmpty(PostalCode))
            {
                yield return new ValidationResult("PostalCode not valid");
            }
        }
    }
}
