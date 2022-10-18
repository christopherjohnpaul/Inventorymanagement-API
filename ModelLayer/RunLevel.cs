using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class RunLevel : BaseEntity
    {
        public RunLevel()
        {
            DriverInfo = new UserInfo();
            StoreInfo = new StoreInfo();
            ProductsInfo = new ProductInformation();
        }
        [Required]
        public int RunNumber { get; set; }
        [Required]
        public long DriverId { get; set; }
        [NotMapped]
        public UserInfo DriverInfo { get; set; }
        [NotMapped]
        public StoreInfo StoreInfo { get; set; }
        [Required]
        public long OrderProductId { get; set; }
        [NotMapped]
        public ProductInformation ProductsInfo { get; set; }
        [NotMapped]
        public Supplier SupplierInfo { get; set; }

        [NotMapped]
        public double Quantity { get; set; }
        [NotMapped]
        public long SupplierId { get; set; }
        [NotMapped]
        public long ProductId { get; set; }
        [NotMapped]
        public long StoreId { get; set; }
        [NotMapped]
        public long OrderId { get; set; }

        public static explicit operator RunLevel(RunLevelModel entity)
        {
            RunLevel model = new RunLevel();
            model.ID = entity.ID;
            model.RunNumber = entity.RunNumber;
            model.DriverId = entity.DriverId;
            model.OrderProductId = entity.OrderProductId;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
    }
}
