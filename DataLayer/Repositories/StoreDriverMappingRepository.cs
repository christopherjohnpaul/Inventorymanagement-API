using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoreDriverMappingRepository : CURDRepository<StoreDriverMapping>, IStoreDriverMappingRepository<StoreDriverMapping>
    {
        public async Task<IList<StoreDriverMapping>> FindAllByCategoryAsync(long driverId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreDriverMapping
                    .Join(context.UserInfo, p => p.DriverId, ui => ui.ID, (p, ui) => new { p, ui })
                    .Join(context.Contact, p => p.ui.ContactId, ct => ct.ID, (p, ct) => new { p, ct })
                    .Join(context.StoreInfo, p => p.p.p.StoreId, st => st.ID, (p, st) => new { p, st })

                    .Where(w => w.p.p.p.DriverId == driverId && w.p.ct.ContactTypeId == 3)
                    .Select(s => new StoreDriverMapping
                    {
                        ID = s.p.p.p.ID,
                        IsActive = s.p.p.p.IsActive,
                        CreatedBy = s.p.p.p.CreatedBy,
                        CreatedDate = s.p.p.p.CreatedDate,
                        ModifiedBy = s.p.p.p.ModifiedBy,
                        ModifiedDate = s.p.p.p.ModifiedDate,
                        StoreId = s.p.p.p.StoreId,
                        DriverId = s.p.p.p.DriverId,
                        DriverInfo = new UserInfo() { ID = s.p.p.ui.ID, ContactId = s.p.p.ui.ContactId, ContactInfo = s.p.ct },
                        Store = s.st,
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }

        public override async Task<IList<StoreDriverMapping>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreDriverMapping
                   .Join(context.UserInfo, p => p.DriverId, ui => ui.ID, (p, ui) => new { p, ui })
                   .Join(context.Contact, p => p.ui.ContactId, ct => ct.ID, (p, ct) => new { p, ct })
                   .Join(context.StoreInfo, p => p.p.p.StoreId, st => st.ID, (p, st) => new { p, st })

                   .Where(w => w.p.p.p.IsActive == true && w.p.ct.ContactTypeId == 3)
                   .Select(s => new StoreDriverMapping
                   {
                       ID = s.p.p.p.ID,
                       IsActive = s.p.p.p.IsActive,
                       CreatedBy = s.p.p.p.CreatedBy,
                       CreatedDate = s.p.p.p.CreatedDate,
                       ModifiedBy = s.p.p.p.ModifiedBy,
                       ModifiedDate = s.p.p.p.ModifiedDate,
                       StoreId = s.p.p.p.StoreId,
                       DriverId = s.p.p.p.DriverId,
                       DriverInfo = new UserInfo() { ID = s.p.p.ui.ID, ContactId = s.p.p.ui.ContactId, ContactInfo = s.p.ct },
                       Store = s.st
                   }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }


        public override async Task<StoreDriverMapping> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreDriverMapping
                   .Join(context.UserInfo, p => p.DriverId, ui => ui.ID, (p, ui) => new { p, ui })
                   .Join(context.Contact, p => p.ui.ContactId, ct => ct.ID, (p, ct) => new { p, ct })
                   .Join(context.StoreInfo, p => p.p.p.StoreId, st => st.ID, (p, st) => new { p, st })

                   .Where(w => w.p.p.p.ID == id && w.p.ct.ContactTypeId == 3)
                   .Select(s => new StoreDriverMapping
                   {
                       ID = s.p.p.p.ID,
                       IsActive = s.p.p.p.IsActive,
                       CreatedBy = s.p.p.p.CreatedBy,
                       CreatedDate = s.p.p.p.CreatedDate,
                       ModifiedBy = s.p.p.p.ModifiedBy,
                       ModifiedDate = s.p.p.p.ModifiedDate,
                       StoreId = s.p.p.p.StoreId,
                       DriverId = s.p.p.p.DriverId,
                       DriverInfo = new UserInfo() { ID = s.p.p.ui.ID, ContactId = s.p.p.ui.ContactId, ContactInfo = s.p.ct },
                       Store = s.st
                   }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
