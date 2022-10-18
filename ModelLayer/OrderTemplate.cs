using ModelLayer.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class OrderTemplate : BaseEntity
    {
        public OrderTemplate()
        {
            Name = " ";
            RegionId = 0;
            TimeOfDelivery = "AM";
            ProductList = new List<OrderTemplateProducts>();
            ExcemptionList = new List<Excemptions>();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long RegionId { get; set; }
        [Required]
        public long DriverId { get; set; }
        [NotMapped]
        public Region RegionInfo { get; set; }
        [Required]
        [MaxLength(2)]
        public string TimeOfDelivery { get; set; }
        public bool DeactivateExcemptions { get; set; }
        public int DayOfWeek { get; set; }
        [NotMapped]
        public List<OrderTemplateProducts> ProductList { get; set; }
        [NotMapped]
        public List<Excemptions> ExcemptionList { get; set; }
        public static explicit operator OrderTemplate(OrderTemplateModel entity)
        {
            OrderTemplate model = new OrderTemplate();
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.RegionId = entity.RegionId;
            model.TimeOfDelivery = entity.TimeOfDelivery;
            model.DeactivateExcemptions = entity.DeactivateExcemptions;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            model.DriverId = entity.DriverId;
            model.DayOfWeek = entity.DayOfWeek;
            return model;
        }
    }
}
