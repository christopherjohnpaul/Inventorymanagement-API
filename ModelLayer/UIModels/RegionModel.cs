using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public  class RegionModel
    {
        public long ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public long CreatedBy { get; set; }
    }
}
