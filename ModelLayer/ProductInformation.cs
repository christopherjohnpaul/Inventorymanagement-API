using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class ProductInformation : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int QuantityPerCrate { get; set; }

        public static explicit operator ProductInformation(ProductInformationModel entity)
        {
            ProductInformation model = new ProductInformation();
            model.ID = entity.ID;
            model.ProductCode = entity.ProductCode;
            model.Name = entity.Name;
            model.Description = entity.Description;
            model.QuantityPerCrate = entity.QuantityPerCrate;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
