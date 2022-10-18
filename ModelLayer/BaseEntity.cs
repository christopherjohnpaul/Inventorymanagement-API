using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            ModifiedBy = null;
            ModifiedDate = null;
            CreatedDate = DateTime.Now;
        }

        [Key]
        public long ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
