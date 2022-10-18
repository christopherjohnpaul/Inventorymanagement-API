using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class StoreInfo : BaseEntity
    {
        public StoreInfo()
        {
            ContactInfo = new Contact();
        }
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public long ContactId { get; set; }
        [NotMapped]
        public Contact ContactInfo { get; set; }

        public static explicit operator StoreInfo(StoreInfoModel entity)
        {
            StoreInfo model = new StoreInfo();
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.Code = entity.Code;
            model.ContactId = entity.ContactId;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
