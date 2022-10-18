using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Region : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public static explicit operator Region(RegionModel entity)
        {
            Region model = new Region();
            model.ID = entity.ID;
            model.Name = entity.Name;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
