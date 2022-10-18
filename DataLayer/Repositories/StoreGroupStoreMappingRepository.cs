using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoreGroupStoreMappingRepository : CURDRepository<StoreGroupStoreMapping>, IStoreGroupStoreMappingRepository<StoreGroupStoreMapping>
    {
        public override async Task<IList<StoreGroupStoreMapping>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreGroupStoreMapping
                    .Join(context.StoreInfo, p => p.StoreId, s => s.ID, (p, s) => new { p, s })
                    .Where(w => w.p.IsActive == true)
                    .Select(s => new StoreGroupStoreMapping
                    {
                        ID = s.p.ID,
                        CreatedBy = s.p.CreatedBy,
                        CreatedDate = s.p.CreatedDate,
                        IsActive = s.p.IsActive,
                        StoreId = s.p.StoreId,
                        StoreGroupId = s.p.StoreGroupId,
                        ModifiedBy = s.p.ModifiedBy,
                        Store = s.s,
                        ModifiedDate = s.p.ModifiedDate
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<StoreGroupStoreMapping> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.StoreGroupStoreMapping
                    .Join(context.StoreInfo, p => p.StoreId, s => s.ID, (p, s) => new { p, s })
                    .Where(w => w.p.ID == id)
                     .Select(s => new StoreGroupStoreMapping
                     {
                         ID = s.p.ID,
                         CreatedBy = s.p.CreatedBy,
                         CreatedDate = s.p.CreatedDate,
                         IsActive = s.p.IsActive,
                         StoreId = s.p.StoreId,
                         StoreGroupId = s.p.StoreGroupId,
                         ModifiedBy = s.p.ModifiedBy,
                         Store = s.s,
                         ModifiedDate = s.p.ModifiedDate
                     }).FirstOrDefaultAsync();
                return obj;
            }
        }
        public async Task<IList<StoreGroupStoreMapping>> FindAllByStoreGroupIdAsync(long storeGroupeId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.StoreGroupStoreMapping
                    .Join(context.StoreInfo, p => p.StoreId, s => s.ID, (p, s) => new { p, s })
                    .Where(w => w.p.StoreGroupId == storeGroupeId)
                     .Select(s => new StoreGroupStoreMapping
                     {
                         ID = s.p.ID,
                         CreatedBy = s.p.CreatedBy,
                         CreatedDate = s.p.CreatedDate,
                         IsActive = s.p.IsActive,
                         StoreId = s.p.StoreId,
                         StoreGroupId = s.p.StoreGroupId,
                         ModifiedBy = s.p.ModifiedBy,
                         Store = s.s,
                         ModifiedDate = s.p.ModifiedDate
                     }).ToListAsync();
                return obj;
            }
        }
    }
}
