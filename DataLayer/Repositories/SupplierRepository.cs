using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SupplierRepository : CURDRepository<Supplier>, ISupplierRepository<Supplier>
    {
        public override async Task<IList<Supplier>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.Supplier
                    .Join(context.Contact, si => si.ContactId, c => c.ID, (si, c) => new { si, c })
                    .Where(w => w.si.IsActive == true)
                    .Select(s => new Supplier
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
                        GenerateOrderEmail = s.si.GenerateOrderEmail,
                        ApplyException = s.si.ApplyException                        
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<Supplier> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.Supplier
                    .Join(context.Contact, si => si.ContactId, c => c.ID, (si, c) => new { si, c })
                    .Where(w => w.si.ID == id)
                    .Select(s => new Supplier
                    {
                        ID = s.si.ID,
                        IsActive = s.si.IsActive,
                        ContactId = s.si.ContactId,
                        ContactInfo = s.c,
                        CreatedBy = s.si.CreatedBy,
                        CreatedDate = s.si.CreatedDate,
                        ModifiedBy = s.si.ModifiedBy,
                        ModifiedDate = s.si.ModifiedDate,
                        Name = s.si.Name
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }
    }
}
