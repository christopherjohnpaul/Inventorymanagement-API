using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("StoreGroupDriverMapping", Schema = "Mapping")]
    public class StoreGroupDriverMapping : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string GroupeName { get; set; }
        [Required]
        public long DriverId { get; set; }
        [NotMapped]
        public UserInfo DriverInfo { get; set; }

        public static explicit operator StoreGroupDriverMapping(StoreGroupDriverMappingModel entity)
        {
            StoreGroupDriverMapping model = new();
            model.ID = entity.ID;
            model.DriverId = entity.DriverId;
            model.GroupeName = entity.GroupeName;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
