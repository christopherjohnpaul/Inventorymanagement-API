using ModelLayer.UIModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("StoreGroupStoreMapping", Schema = "Mapping")]
    public class StoreGroupStoreMapping : BaseEntity
    {
        [Required]
        public long StoreGroupId { get; set; }
        [Required]
        public long StoreId { get; set; }
        //[NotMapped]
        //public UserInfo DriverInfo { get; set; }
        [NotMapped]
        public StoreInfo Store { get; set; }

        public static explicit operator StoreGroupStoreMapping(StoreGroupStoreMappingModel entity)
        {
            StoreGroupStoreMapping model = new();
            model.ID = entity.ID;
            model.StoreGroupId = entity.StoreGroupId;
            model.StoreId = entity.StoreId;
            model.CreatedBy = entity.CreatedBy;
            return model;
        }
    }
}
