using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class AddProductsModel: IValidatableObject
    {
        public long ID { get; set; }
        public List<long> StoreIdList { get; set; }
        public long CreatedBy { get; set; }
        public long SupplierId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ID <= 0)
            {
                yield return new ValidationResult("ID not valid");
            }
            if (StoreIdList.Count <= 0)
            {
                yield return new ValidationResult("StoreIdList not valid");
            }
            if (SupplierId <= 0)
            {
                yield return new ValidationResult("SupplierId not valid");
            }
        }
    }
}
