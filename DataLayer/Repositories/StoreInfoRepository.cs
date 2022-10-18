using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoreInfoRepository : CURDRepository<StoreInfo>, IStoreInfoRepository<StoreInfo>
    {
        public override async Task<IList<StoreInfo>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreInfo
                    .Join(context.Contact, si => si.ContactId, c => c.ID, (si, c) => new { si, c })
                    .Where(w => w.si.IsActive == true)
                    .Select(s => new StoreInfo
                    {
                        ID = s.si.ID,
                        IsActive = s.si.IsActive,
                        ContactId = s.si.ContactId,
                        ContactInfo = s.c,
                        CreatedBy = s.si.CreatedBy,
                        CreatedDate = s.si.CreatedDate,
                        ModifiedBy = s.si.ModifiedBy,
                        ModifiedDate = s.si.ModifiedDate,
                        Name = s.si.Name,
                        Code=s.si.Code
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<StoreInfo> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.StoreInfo
                     .Join(context.Contact, si => si.ContactId, c => c.ID, (si, c) => new { si, c })
                    .Where(w => w.si.ID == id)
                    .Select(s => new StoreInfo
                    {
                        ID = s.si.ID,
                        IsActive = s.si.IsActive,
                        ContactId = s.si.ContactId,
                        ContactInfo = s.c,
                        CreatedBy = s.si.CreatedBy,
                        CreatedDate = s.si.CreatedDate,
                        ModifiedBy = s.si.ModifiedBy,
                        ModifiedDate = s.si.ModifiedDate,
                        Name = s.si.Name,
                        Code = s.si.Code
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }

        public async Task<IList<StoreInfo>> GetAllBySupplierId(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var products = await context.Supplier
                    .Join(context.ProductSupplierUnitPrice, spu => spu.ID, psu => psu.SupplierId, (spu, psu) => new { spu, psu })
                    .Where(w => w.spu.ID == id)
                    .Select(s => s.psu.ProductId).ToListAsync();

                var obj = await context.StoreInfo
                     .Join(context.CategoryStore, p => p.ID, cst => cst.StoreId, (p, cst) => new { p, cst })
                     .Join(context.CategoryProduct, p => p.cst.CategoryId, ctp => ctp.CategoryId, (p, ctp) => new { p, ctp })
                    .Where(w => products.Contains( w.ctp.ProductId) )
                    .Select(s => new StoreInfo
                    {
                        ID = s.p.p.ID,
                        IsActive = s.p.p.IsActive,
                        ContactId = s.p.p.ContactId,
                        CreatedBy = s.p.p.CreatedBy,
                        CreatedDate = s.p.p.CreatedDate,
                        ModifiedBy = s.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.ModifiedDate,
                        Name = s.p.p.Name,
                        Code = s.p.p.Code
                    }).Distinct().ToListAsync();
                return obj;
            }
        }
    }
}
