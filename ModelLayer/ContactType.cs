using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("ContactType", Schema = "Lookup")]
    public class ContactType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public static explicit operator ContactType(ContactTypeModel entity)
        {
            ContactType model = new();
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
