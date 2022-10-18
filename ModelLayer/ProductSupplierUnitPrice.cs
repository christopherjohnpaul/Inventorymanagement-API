using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("ProductSupplierUnitPrice", Schema = "Mapping")]
    public class ProductSupplierUnitPrice : BaseEntity
    {
        public ProductSupplierUnitPrice()
        {
            ProductInfo = new ProductInformation();
        }
        [Required]
        public long ProductId { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [Required]
        public long SupplierId { get; set; }
        [NotMapped]
        public Supplier SupplierInfo { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime EffectiveFromDate { get; set; }
        public DateTime? EffectiveTillDate { get; set; }

        public static explicit operator ProductSupplierUnitPrice(ProductSupplierUnitPriceModel entity)
        {
            ProductSupplierUnitPrice model = new ProductSupplierUnitPrice();
            model.ID = entity.ID;
            model.ProductId = entity.ProductId;
            model.SupplierId = entity.SupplierId;
            model.UnitPrice = entity.UnitPrice;
            model.EffectiveFromDate = entity.EffectiveFromDate;
            model.EffectiveTillDate = entity.EffectiveTillDate;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
