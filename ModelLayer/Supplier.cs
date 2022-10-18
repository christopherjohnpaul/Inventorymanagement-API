using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            ContactInfo = new Contact();
        }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public long ContactId { get; set; }
        [NotMapped]
        public Contact ContactInfo { get; set; }
        [Required]
        public bool GenerateOrderEmail { get; set; }
        [Required]
        public bool ApplyException { get; set; }

        public static explicit operator Supplier(SupplierModel entity)
        {
            Supplier model = new Supplier();
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.ContactId = entity.ContactId;
            model.GenerateOrderEmail = entity.GenerateOrderEmail;
            model.ApplyException = entity.ApplyException;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
