using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class UserInfoModel : IValidatableObject
    {
        public long ID { get; set; }

        public ContactModel ContactInfo { get; set; }
        public long CreatedBy { get; set; }
        public bool IsLoginEnabled { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ContactInfo.FirstName))
            {
                yield return new ValidationResult("FirstName not valid");
            }
            //if (string.IsNullOrEmpty(ContactInfo.LastName))
            //{
            //    yield return new ValidationResult("LastName not valid");
            //}
            //if (string.IsNullOrEmpty(ContactInfo.Email))
            //{
            //    yield return new ValidationResult("Email not valid");
            //}
            //if (string.IsNullOrEmpty(ContactInfo.MobileNumber))
            //{
            //    yield return new ValidationResult("MobileNumber not valid");
            //}
            if (ContactInfo.ContactTypeId <= 0)
            {
                yield return new ValidationResult("UserTypeId not valid");
            }
        }
    }
}
