using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoreGroupDriverMappingRepository : CURDRepository<StoreGroupDriverMapping>, IStoreGroupDriverMappingRepository<StoreGroupDriverMapping>
    {
        public override async Task<IList<StoreGroupDriverMapping>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreGroupDriverMapping
                    .Join(context.UserInfo, p => p.DriverId, u => u.ID, (p, u) => new { p, u })
                    .Join(context.Contact, p => p.u.ContactId, c => c.ID, (p, c) => new { p, c })
                    .Where(w => w.p.p.IsActive == true)
                    .Select(s => new StoreGroupDriverMapping
                    {
                        ID = s.p.p.ID,
                        CreatedBy = s.p.p.CreatedBy,
                        CreatedDate = s.p.p.CreatedDate,
                        IsActive = s.p.p.IsActive,
                        ModifiedBy = s.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.ModifiedDate,
                        DriverId = s.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.u.ID, ContactInfo = s.c },
                        GroupeName = s.p.p.GroupeName
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<StoreGroupDriverMapping> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreGroupDriverMapping
                    .Join(context.UserInfo, p => p.DriverId, u => u.ID, (p, u) => new { p, u })
                    .Join(context.Contact, p => p.u.ContactId, c => c.ID, (p, c) => new { p, c })
                    .Where(w => w.p.p.ID == id)
                    .Select(s => new StoreGroupDriverMapping
                    {
                        ID = s.p.p.ID,
                        CreatedBy = s.p.p.CreatedBy,
                        CreatedDate = s.p.p.CreatedDate,
                        IsActive = s.p.p.IsActive,
                        ModifiedBy = s.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.ModifiedDate,
                        DriverId = s.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.u.ID, ContactInfo = s.c },
                        GroupeName = s.p.p.GroupeName
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
