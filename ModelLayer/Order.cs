using ModelLayer.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDay = DateTime.Now;
            OrderTemplateId = 0;
            DriverId = 0;
            TimeOfDelivery = "AM";
            ProductList = new List<OrderProducts>();
        }
        [Required]
        public DateTime OrderDay { get; set; }
        [Required]
        public long OrderTemplateId { get; set; }
        [NotMapped]
        public OrderTemplate OrderTemplateInfo { get; set; }
        [Required]
        public long DriverId { get; set; }
        public bool IsOrderFinalized { get; set; }
        public bool IsSupplierMailSent { get; set; }
        public DateTime SupplierMailSentTime { get; set; }
        public bool IsRunGenarated { get; set; }
        [NotMapped]
        public Contact DriverInfo { get; set; }
        [Required]
        [MaxLength(2)]
        public string TimeOfDelivery { get; set; }
        [NotMapped]
        public List<OrderProducts> ProductList { get; set; }

        public static explicit operator Order(OrderModel entity)
        {
            Order model = new Order();
            model.ID = entity.ID;
            model.OrderDay = entity.OrderDay;
            model.OrderTemplateId = entity.OrderTemplateId;
            model.DriverId = entity.DriverId;
            model.TimeOfDelivery = entity.TimeOfDelivery;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            //model.IsOrderFinalized = true;
            return model;
        }
    }
}
