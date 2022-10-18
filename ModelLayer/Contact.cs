using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("Contact", Schema = "Admin")]
    public class Contact : BaseEntity
    {
        public Contact()
        {
            this.ContactTypeInfo = new ContactType();
        }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(15)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string MobileNumber { get; set; }
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [MaxLength(60)]
        public long LocationId { get; set; }
        [NotMapped]
        public Location LocationInfo { get; set; }
        public long ContactTypeId { get; set; }
        [NotMapped]
        public ContactType ContactTypeInfo { get; set; }

        public static explicit operator Contact(ContactModel entity)
        {
            Contact model = new();
            model.ID = entity.ID;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.MobileNumber = entity.MobileNumber;
            model.Email = entity.Email;
            model.LocationId = entity.LocationId;
            model.ContactTypeId = entity.ContactTypeId;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
