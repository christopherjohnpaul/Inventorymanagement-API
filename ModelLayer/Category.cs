using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("Category", Schema = "Mapping")]
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
      
        public string Name { get; set; }
        public static explicit operator Category(CategoryModel entity)
        {
            Category model = new()
            {
                ID = entity.ID,
                Name = entity.Name,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now
            };
            return model;
        }
    }
}
