using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("OrderProducts", Schema = "Mapping")]
    public class OrderProducts : BaseEntity
    {
        public OrderProducts()
        {
            ProductInfo = new();
            StoreInfo = new();
        }
        [Required]
        public long OrderId { get; set; }
       
        [Required]
        public long ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int SalesDay { get; set; }
        [Required]
        public long SupplierId { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [NotMapped]
        public StoreInfo StoreInfo { get; set; }
        [Required]
        public int SequenceNumber { get; set; }
        [Required]
        public long StoreId { get; set; }
        [Required]
        public long TemplateId { get; set; }

        public static explicit operator OrderProducts(OrderProductsModel entity)
        {
            OrderProducts model = new();
            model.ID = entity.ID;
            model.OrderId = entity.OrderId;
            model.ProductId = entity.ProductId;
            model.StoreId = entity.StoreId;
            model.SequenceNumber = entity.SequenceNumber;
            model.Quantity = entity.Quantity;
            model.SalesDay = entity.SalesDay;
            model.IsActive = entity.IsActive;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            model.TemplateId = entity.TemplateId;
            model.SupplierId = entity.SupplierId;
            return model;
        }
    }
}
