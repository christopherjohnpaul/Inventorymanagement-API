using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RunLevelRepository : CURDRepository<RunLevel>, IRunLevelRepository<RunLevel>
    {
        public override async Task<IList<RunLevel>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.RunLevel
                  // .Join(context.StoreDriverMapping, p => p.DriverId, sdm => sdm.ID, (p, sdm) => new { p, sdm })
                    .Join(context.UserInfo, p => p.DriverId, u => u.ID, (p, u) => new { p, u })
                    .Join(context.Contact, p => p.u.ContactId, c => c.ID, (p, c) => new { p, c })
                    .Join(context.OrderProducts, p => p.p.p.OrderProductId, op => op.ID, (p, op) => new { p, op })
                    .Join(context.ProductInformation, p => p.op.ProductId, pr => pr.ID, (p, pr) => new { p, pr })
                     .Join(context.Supplier, p => p.p.op.SupplierId, sup => sup.ID, (p, sup) => new { p, sup })
                     .Join(context.StoreInfo, p => p.p.p.op.StoreId, st => st.ID, (p, st) => new { p, st })
                    .Where(w => w.p.p.p.p.p.p.IsActive == true)
                    .Select(s => new RunLevel
                    {
                        IsActive = s.p.p.p.p.p.p.IsActive,
                        CreatedBy = s.p.p.p.p.p.p.CreatedBy,
                        CreatedDate = s.p.p.p.p.p.p.CreatedDate,
                        ModifiedBy = s.p.p.p.p.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.p.p.p.p.ModifiedDate,
                        ID = s.p.p.p.p.p.p.ID,
                        RunNumber = s.p.p.p.p.p.p.RunNumber,
                        OrderProductId = s.p.p.p.p.p.p.OrderProductId,
                        DriverId = s.p.p.p.p.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.p.p.p.p.u.ID, ContactId = s.p.p.p.p.p.u.ContactId, ContactInfo = s.p.p.p.p.c },
                        ProductsInfo = s.p.p.pr,
                        StoreInfo = s.st,
                        Quantity = s.p.p.p.op.Quantity,
                        SupplierInfo = s.p.sup,
                        OrderId = s.p.p.p.op.OrderId,
                        ProductId = s.p.p.p.op.ProductId,
                        StoreId = s.p.p.p.op.StoreId,
                        SupplierId = s.p.p.p.op.SupplierId,
                    }).ToListAsync();
                return result;
            }
        }

        public async Task<IList<RunLevel>> FindAllByOrderIdAsync(long orderId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.RunLevel
                    .Join(context.UserInfo, p => p.DriverId, u => u.ID, (p, u) => new { p, u })
                    .Join(context.Contact, p => p.u.ContactId, c => c.ID, (p, c) => new { p, c })
                    .Join(context.OrderProducts, p => p.p.p.OrderProductId, op => op.ID, (p, op) => new { p, op })
                    .Join(context.ProductInformation, p => p.op.ProductId, pr => pr.ID, (p, pr) => new { p, pr })
                     .Join(context.Supplier, p => p.p.op.SupplierId, sup => sup.ID, (p, sup) => new { p, sup })
                     .Join(context.StoreInfo, p => p.p.p.op.StoreId, st => st.ID, (p, st) => new { p, st })
                    .Where(w => w.p.p.p.op.OrderId == orderId)
                    .Select(s => new RunLevel
                    {
                        IsActive = s.p.p.p.p.p.p.IsActive,
                        CreatedBy = s.p.p.p.p.p.p.CreatedBy,
                        CreatedDate = s.p.p.p.p.p.p.CreatedDate,
                        ModifiedBy = s.p.p.p.p.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.p.p.p.p.ModifiedDate,
                        ID = s.p.p.p.p.p.p.ID,
                        RunNumber = s.p.p.p.p.p.p.RunNumber,
                        OrderProductId = s.p.p.p.p.p.p.OrderProductId,
                        DriverId = s.p.p.p.p.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.p.p.p.p.u.ID, ContactId = s.p.p.p.p.p.u.ContactId, ContactInfo = s.p.p.p.p.c },
                        ProductsInfo = s.p.p.pr,
                        StoreInfo = s.st,
                        Quantity = s.p.p.p.op.Quantity,
                        SupplierInfo = s.p.sup,
                        OrderId = s.p.p.p.op.OrderId,
                        ProductId = s.p.p.p.op.ProductId,
                        StoreId = s.p.p.p.op.StoreId,
                        SupplierId = s.p.p.p.op.SupplierId,
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<RunLevel> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.RunLevel
                    .Join(context.UserInfo, p => p.DriverId, u => u.ID, (p, u) => new { p, u })
                    .Join(context.Contact, p => p.u.ContactId, c => c.ID, (p, c) => new { p, c })
                    .Join(context.OrderProducts, p => p.p.p.OrderProductId, op => op.ID, (p, op) => new { p, op })
                    .Join(context.ProductInformation, p => p.op.ProductId, pr => pr.ID, (p, pr) => new { p, pr })
                     .Join(context.Supplier, p => p.p.op.SupplierId, sup => sup.ID, (p, sup) => new { p, sup })
                     .Join(context.StoreInfo, p => p.p.p.op.StoreId, st => st.ID, (p, st) => new { p, st })
                    .Where(w => w.p.p.p.p.p.p.ID == id)
                    .Select(s => new RunLevel
                    {
                        IsActive = s.p.p.p.p.p.p.IsActive,
                        CreatedBy = s.p.p.p.p.p.p.CreatedBy,
                        CreatedDate = s.p.p.p.p.p.p.CreatedDate,
                        ModifiedBy = s.p.p.p.p.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.p.p.p.p.ModifiedDate,
                        ID = s.p.p.p.p.p.p.ID,
                        RunNumber = s.p.p.p.p.p.p.RunNumber,
                        OrderProductId = s.p.p.p.p.p.p.OrderProductId,
                        DriverId = s.p.p.p.p.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.p.p.p.p.u.ID, ContactId = s.p.p.p.p.p.u.ContactId, ContactInfo = s.p.p.p.p.c },
                        ProductsInfo = s.p.p.pr,
                        StoreInfo = s.st,
                        Quantity = s.p.p.p.op.Quantity,
                        SupplierInfo = s.p.sup,
                        OrderId = s.p.p.p.op.OrderId,
                        ProductId = s.p.p.p.op.ProductId,
                        StoreId = s.p.p.p.op.StoreId,
                        SupplierId = s.p.p.p.op.SupplierId,
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
