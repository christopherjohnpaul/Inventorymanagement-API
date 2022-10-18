using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("CategoryProduct", Schema = "Mapping")]
    public class CategoryProduct : BaseEntity
    {
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long ProductId { get; set; }
        [NotMapped]
        public Category CategoryInfo { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [Required]
        public string ArticleNumber { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public static explicit operator CategoryProduct(CategoryProductModel entity)
        {
            CategoryProduct model = new()
            {
                ID = entity.ID,
                CategoryId = entity.CategoryId,
                ProductId = entity.ProductId,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now,
                ArticleNumber = entity.ArticleNumber,
                UnitPrice=entity.UnitPrice
            };
            return model;
        }
    }
}
