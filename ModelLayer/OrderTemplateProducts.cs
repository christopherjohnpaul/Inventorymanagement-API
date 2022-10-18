using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class OrderTemplateProducts : BaseEntity
    {
        public OrderTemplateProducts()
        {
            ProductInfo = new();
            StoreInfo = new();
        }
        [Required]
        public long OrderTemplateId { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public long SupplierId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int SalesDay { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [NotMapped]
        public StoreInfo StoreInfo { get; set; }
        [Required]
        public int SequenceNumber { get; set; }
        [Required]
        public long StoreId { get; set; }

        public static explicit operator OrderTemplateProducts(OrderTemplateProductsModel entity)
        {
            OrderTemplateProducts model = new();
            model.ID = entity.ID;
            model.OrderTemplateId = entity.OrderTemplateId;
            model.Quantity = entity.Quantity;
            model.SalesDay = entity.SalesDay;
            model.ProductId = entity.ProductId;
            model.IsActive = entity.IsActive;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            model.SequenceNumber = entity.SequenceNumber;
            model.StoreId = entity.StoreId;
            model.SupplierId = entity.SupplierId;
            return model;
        }
    }
}
