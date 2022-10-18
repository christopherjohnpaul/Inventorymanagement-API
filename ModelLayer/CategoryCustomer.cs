using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("CategoryCustomer", Schema = "Mapping")]
    public class CategoryCustomer : BaseEntity
    {
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public long CustomerMasterId { get; set; }
        [NotMapped]
        public Category CategoryInfo { get; set; }
        [NotMapped]
        public CustomerMaster CustomerMasterInfo { get; set; }
        public static explicit operator CategoryCustomer(CategoryCustomerModel entity)
        {
            CategoryCustomer model = new()
            {
                ID = entity.ID,
                CategoryId = entity.CategoryId,
                CustomerMasterId = entity.CustomerMasterId,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now
            };
            return model;
        }
    }
}
