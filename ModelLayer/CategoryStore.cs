using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("CategoryStore", Schema = "Mapping")]
    public class CategoryStore : BaseEntity
    {
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long StoreId { get; set; }
        [NotMapped]
        public Category CategoryInfo { get; set; }
        [NotMapped]
        public StoreInfo StoreInfoDetails { get; set; }
        public static explicit operator CategoryStore(CategoryStoreModel entity)
        {
            CategoryStore model = new()
            {
                ID = entity.ID,
                CategoryId = entity.CategoryId,
                StoreId = entity.StoreInfoId,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now
            };
            return model;
        }
    }
}
