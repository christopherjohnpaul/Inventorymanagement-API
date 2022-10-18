using System;
using System.ComponentModel.DataAnnotations;

namespace nventoryManagementWebApi.Models
{
    public class ProductSupplierUnitPriceModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public DateTime EffectiveFromDate { get; set; }
        public DateTime? EffectiveTillDate { get; set; }
    }
}
