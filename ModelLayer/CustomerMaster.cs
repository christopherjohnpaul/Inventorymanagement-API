using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class CustomerMaster : BaseEntity
    {
        public CustomerMaster()
        {
            CustomerTypeInfo = new CustomerType();
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        //[MaxLength(50)]
        public long CustomerTypeId { get; set; }
        [NotMapped]
        public CustomerType CustomerTypeInfo { get; set; }
        [Required]
        public bool IndividualPrice { get; set; }
        [Required]
        [MaxLength(100)]
        public string PriceLevel { get; set; }
        [Required]
        public long ContactId { get; set; }
        [NotMapped]
        public Contact ContactInfo { get; set; }

        public static explicit operator CustomerMaster(CustomerMasterModel entity)
        {
            CustomerMaster model = new CustomerMaster();
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.ContactId = entity.ContactId;
            model.CustomerTypeId = entity.CustomerTypeId;
            model.IndividualPrice = entity.IndividualPrice;
            model.PriceLevel = entity.PriceLevel;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
