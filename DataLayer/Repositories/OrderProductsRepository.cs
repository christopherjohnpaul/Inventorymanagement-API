using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderProductsRepository : CURDRepository<OrderProducts>, IOrderProductsRepository<OrderProducts>
    {
        public async Task<IList<OrderProducts>> GetAllByOrderIdAsyn(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderId == id)
                        .Select
                        (s => new OrderProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderId = s.pcup.pcup.OrderId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st,
                            TemplateId = s.pcup.pcup.TemplateId
                        }).ToListAsync();
                return result;
            }
        }
        public async Task<bool> UpsertByOrderTemplateId(long orderId, long templateId)
        {
            bool result = true;
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                List<OrderProducts> orderProductsList = await context.OrderTemplateProducts
                    .Where(w => w.OrderTemplateId == templateId && !context.OrderProducts.Any(op => op.OrderId == orderId && op.ProductId == w.ProductId))
                    .Select
                        (s => new OrderProducts
                        {
                            OrderId = orderId,
                            Quantity = s.Quantity,
                            SalesDay = s.SalesDay,
                            CreatedBy = 0,
                            CreatedDate = DateTime.Now
                        }).ToListAsync();

                if (orderProductsList.Count > 0)
                {
                    await context.OrderProducts.AddRangeAsync(orderProductsList);
                    await context.SaveChangesAsync();
                }
            }

            return result;
        }
        public async Task<IList<OrderProducts>> GetAllByProductIdAsync(long orderId, List<long> productIdList)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderId == orderId && productIdList.Contains(w.pcup.pcup.ProductId))
                        .Select
                        (s => new OrderProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderId = s.pcup.pcup.OrderId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st,
                            TemplateId = s.pcup.pcup.TemplateId
                        }).ToListAsync();
                return result;
            }
        }
        public async Task<IList<OrderProducts>> GetAllBySupplierIdandOrderIdAsync(long orderId, long supplierId, long templateId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.OrderProducts
                        .Join(context.ProductInformation, pcup => pcup.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Join(context.StoreInfo, pcup => pcup.pcup.StoreId, st => st.ID, (pcup, st) => new { pcup, st })
                        .Where(w => w.pcup.pcup.OrderId == orderId && w.pcup.pcup.SupplierId == supplierId && w.pcup.pcup.TemplateId== templateId)
                        .Select
                        (s => new OrderProducts
                        {
                            ID = s.pcup.pcup.ID,
                            ProductInfo = s.pcup.pi,
                            CreatedBy = s.pcup.pcup.CreatedBy,
                            CreatedDate = s.pcup.pcup.CreatedDate,
                            IsActive = s.pcup.pcup.IsActive,
                            ModifiedBy = s.pcup.pcup.ModifiedBy,
                            ModifiedDate = s.pcup.pcup.ModifiedDate,
                            OrderId = s.pcup.pcup.OrderId,
                            Quantity = s.pcup.pcup.Quantity,
                            SalesDay = s.pcup.pcup.SalesDay,
                            ProductId = s.pcup.pcup.ProductId,
                            SequenceNumber = s.pcup.pcup.SequenceNumber,
                            StoreId = s.pcup.pcup.StoreId,
                            SupplierId = s.pcup.pcup.SupplierId,
                            StoreInfo = s.st,
                            TemplateId = s.pcup.pcup.TemplateId
                        }).Distinct().ToListAsync();
                return result;
            }
        }

        public async Task<bool> SaveProductQuantity(long id, double quantity, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.OrderProducts.FindAsync(id);
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
                var item = await context.OrderProducts.FindAsync(id);
                context.OrderProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
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
                var item = await context.OrderProducts.FindAsync(id);
                context.OrderProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
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
                var item = await context.OrderProducts.FindAsync(id);
                context.OrderProducts.ToList().FindAll(otp => otp.StoreId == item.StoreId && otp.SupplierId == supplierId).ForEach(itm =>
                  {
                      itm.ModifiedBy = createdBy;
                      itm.ModifiedDate = System.DateTime.Now;
                      itm.IsActive = enable;
                      context.SaveChanges();
                  });
            }
            return true;
        }
        public async Task<bool> DeleteByOrderId(long orderId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                context.OrderProducts.ToList().RemoveAll(op => op.OrderId == orderId);
                context.SaveChanges();
            }
            return true;
        }
    }
}
