﻿using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("ProductCustomerUnitPrice", Schema = "Mapping")]
    public class ProductCustomerUnitPrice : BaseEntity
    {
        public ProductCustomerUnitPrice()
        {
            CustomerMasterInfo = new CustomerMaster();
            ProductInfo = new ProductInformation();
        }
        [Required]
        public long CustomerMasterId { get; set; }
        [NotMapped]
        public CustomerMaster CustomerMasterInfo { get; set; }
        [Required]
        public long ProductId { get; set; }
        [NotMapped]
        public ProductInformation ProductInfo { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime EffectiveFromDate { get; set; }
        public DateTime? EffectiveTillDate { get; set; }

        public static explicit operator ProductCustomerUnitPrice(ProductCustomerUnitPriceModel entity)
        {
            ProductCustomerUnitPrice model = new ProductCustomerUnitPrice();
            model.ID = entity.ID;
            model.CustomerMasterId = entity.CustomerMasterId;
            model.ProductId = entity.ProductId;
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
