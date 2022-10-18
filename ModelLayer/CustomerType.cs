using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("CustomerType", Schema = "Lookup")]
    public class CustomerType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public static explicit operator CustomerType(CustomerTypeModel entity)
        {
            CustomerType model = new();
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
