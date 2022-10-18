using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataLayer.Repositories
{
    public class OrderTemplateProductsRepository : CURDRepository<OrderTemplateProducts>, IOrderTemplateProductsRepository<OrderTemplateProducts>
    {
        public async Task<IList<OrderTemplateProducts>> GetAllByTemplateIdAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderTemplateProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderTemplateId == id)
                        .Select
                        (s => new OrderTemplateProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderTemplateId = s.pcup.pcup.OrderTemplateId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st
                        }).ToListAsync();
                return result;
            }
        }

        public async Task<IList<OrderTemplateProducts>> GetAllByProductIdAsync(long orderTemplateId, List<long> productIdList)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderTemplateProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderTemplateId == orderTemplateId && productIdList.Contains(w.pcup.pcup.ProductId))
                        .Select
                        (s => new OrderTemplateProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderTemplateId = s.pcup.pcup.OrderTemplateId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st
                        }).ToListAsync();
                return result;
            }
        }

        public async Task<IList<OrderTemplateProducts>> GetAllBySupplierIdAndTemplateIdAsync(long orderTemplateId, long supplierId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderTemplateProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderTemplateId == orderTemplateId && w.pcup.pcup.SupplierId == supplierId)
                        .Select
                        (s => new OrderTemplateProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderTemplateId = s.pcup.pcup.OrderTemplateId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st
                        }).Distinct().ToListAsync();
                return result;
            }
        }

        public async Task<bool> SaveProductQuantity(long id, double quantity, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.OrderTemplateProducts.FindAsync(id);
                item.Quantity = quantity;
                item.ModifiedBy = createdBy;
                item.ModifiedDate = System.DateTime.Now;
                context.SaveChanges();
            }

            return true;
        }
        public async Task<bool> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.OrderTemplateProducts.FindAsync(id);
                context.OrderTemplateProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
                  {
                      itm.SequenceNumber = sequenceNumber;
                      itm.ModifiedBy = createdBy;
                      itm.ModifiedDate = System.DateTime.Now;
                      context.SaveChanges();
                  });

            }
            return true;
        }
        public async Task<bool> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.OrderTemplateProducts.FindAsync(id);
                context.OrderTemplateProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
                  {
                      itm.SalesDay = salesDay;
                      itm.ModifiedBy = createdBy;
                      itm.ModifiedDate = System.DateTime.Now;
                      context.SaveChanges();
                  });
            }
            return true;
        }
        public async Task<bool> EnableDisable(long id, long supplierId, bool enable, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.OrderTemplateProducts.FindAsync(id);
                context.OrderTemplateProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
                  {
                      itm.ModifiedBy = createdBy;
                      itm.ModifiedDate = System.DateTime.Now;
                      itm.IsActive = enable;
                      context.SaveChanges();
                  });
            }
            return true;
        }
    }
}
