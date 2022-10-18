using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Excemptions : BaseEntity
    {
        [Required]
        public long OrderTemplateId { get; set; }
        [Required]
        public double MultiplyOders { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }


        public static explicit operator Excemptions(ExcemptionsModel entity)
        {
            Excemptions model = new Excemptions();
            model.ID = entity.ID;
            model.OrderTemplateId = entity.OrderTemplateId;
            model.MultiplyOders = entity.MultiplyOders;
            model.FromDate = entity.FromDate;
            model.ToDate = entity.ToDate;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;

            return model;
        }
    }
}
