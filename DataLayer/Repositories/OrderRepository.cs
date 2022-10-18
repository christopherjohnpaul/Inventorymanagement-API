using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderRepository : CURDRepository<Order>, IOrderRepository<Order>
    {
        public override async Task<IList<Order>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.Order
                    .Select(s => new Order
                    {
                        ID = s.ID,
                        IsActive = s.IsActive,
                        CreatedBy = s.CreatedBy,
                        CreatedDate = s.CreatedDate,
                        ModifiedBy = s.ModifiedBy,
                        ModifiedDate = s.ModifiedDate,
                        DriverId = s.DriverId,
                        OrderDay = s.OrderDay,
                        OrderTemplateId = s.OrderTemplateId,
                        TimeOfDelivery = s.TimeOfDelivery,
                        IsRunGenarated = s.IsRunGenarated,
                        IsOrderFinalized = s.IsOrderFinalized,
                        IsSupplierMailSent = s.IsSupplierMailSent,
                        SupplierMailSentTime = s.SupplierMailSentTime
                    }).OrderBy(o => o.OrderDay).ToListAsync();

                return result;
            }
        }
        public override async Task<Order> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var productList = await context.Set<OrderProducts>().Where(w => w.OrderId == id).ToListAsync();
                var result = await context.Order.Where(w => w.ID == id)
                    .Select(s => new Order
                    {
                        ID = s.ID,
                        IsActive = s.IsActive,
                        CreatedBy = s.CreatedBy,
                        CreatedDate = s.CreatedDate,
                        ModifiedBy = s.ModifiedBy,
                        ModifiedDate = s.ModifiedDate,
                        DriverId = s.DriverId,
                        OrderDay = s.OrderDay,
                        OrderTemplateId = s.OrderTemplateId,
                        TimeOfDelivery = s.TimeOfDelivery,
                        ProductList = productList,
                        IsRunGenarated = s.IsRunGenarated,
                        IsOrderFinalized = s.IsOrderFinalized,
                        IsSupplierMailSent = s.IsSupplierMailSent,
                        SupplierMailSentTime = s.SupplierMailSentTime
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
        public async Task<bool> FinalizeOrder(long id, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.Order.FindAsync(id);
                item.IsOrderFinalized = true;
                item.ModifiedBy = createdBy;
                item.ModifiedDate = System.DateTime.Now;
                context.SaveChanges();
            }

            return true;
        }
        public async Task<bool> RunGenerated(long id, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.Order.FindAsync(id);
                item.IsRunGenarated = true;
                item.ModifiedBy = createdBy;
                item.ModifiedDate = System.DateTime.Now;
                context.SaveChanges();
            }

            return true;
        }
        public async Task<bool> MailSendToSupplier(long id, long createdBy)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var item = await context.Order.FindAsync(id);
                item.IsSupplierMailSent = true;
                item.SupplierMailSentTime = DateTime.Now;
                item.ModifiedBy = createdBy;
                item.ModifiedDate = DateTime.Now;
                context.SaveChanges();
            }

            return true;
        }
    }
}
