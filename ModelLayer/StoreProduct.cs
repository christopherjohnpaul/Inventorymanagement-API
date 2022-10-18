using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("StoreProduct", Schema = "Mapping")]
    public class StoreProduct : BaseEntity
    {
        public StoreProduct()
        {
            ProductInfo = new ProductInformation();
            StoreDetailsInfo = new StoreInfo();
        }
        [Required]
        [MaxLength(100)]
        public string ArticleNumber { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long StoreId { get; set; }
        [NotMapped]
        public string Group { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [NotMapped]
        public StoreInfo StoreDetailsInfo { get; set; }
        public static explicit operator StoreProduct(StoreProductModel entity)
        {
            StoreProduct model = new()
            {
                ID = entity.ID,
                ArticleNumber = entity.ArticleNumber,
                ProductId = entity.ProductId,
                StoreId = entity.StoreId,
                Description = entity.Description,
                Group = entity.Group,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now
            };
            return model;
        }
    }
}
