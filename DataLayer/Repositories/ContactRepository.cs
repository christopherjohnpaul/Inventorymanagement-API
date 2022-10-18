using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ContactRepository : CURDRepository<Contact>, IContactRepository<Contact>
    {
        public override async Task<IList<Contact>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.Contact
                    .Join(context.ContactType, c => c.ContactTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Location, c => c.c.LocationId, l => l.ID, (c, l) => new { c, l })
                    .Where(w => w.c.c.IsActive == true)
                    .Select(s => new Contact
                    {
                        ID = s.c.c.ID,
                        ContactTypeId = s.c.c.ContactTypeId,
                        ContactTypeInfo = s.c.ct,
                        CreatedBy = s.c.c.CreatedBy,
                        CreatedDate = s.c.c.CreatedDate,
                        Email = s.c.c.Email,
                        FirstName = s.c.c.FirstName,
                        LastName = s.c.c.LastName,
                        LocationId = s.c.c.LocationId,
                        LocationInfo = s.l
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<Contact> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.Contact
                    .Join(context.ContactType, c => c.ContactTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Location, c => c.c.LocationId, l => l.ID, (c, l) => new { c, l })
                    .Where(w => w.c.c.ID == id)
                    .Select(s => new Contact
                    {
                        ID = s.c.c.ID,
                        ContactTypeId = s.c.c.ContactTypeId,
                        ContactTypeInfo = s.c.ct,
                        CreatedBy = s.c.c.CreatedBy,
                        CreatedDate = s.c.c.CreatedDate,
                        Email = s.c.c.Email,
                        FirstName = s.c.c.FirstName,
                        LastName = s.c.c.LastName,
                        LocationId = s.c.c.LocationId,
                        LocationInfo = s.l
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }
        public async Task<IList<Contact>> GetAllByContactTypeAsync(long contactTypeId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                //var defaultContact = await context.Contact
                //    .Where(w => w.ContactTypeId == contactTypeId && w.FirstName.ToUpper().Equals("No Contact".ToUpper())).FirstOrDefaultAsync();

                var result = await context.Contact
                    .Join(context.ContactType, c => c.ContactTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Location, c => c.c.LocationId, l => l.ID, (c, l) => new { c, l })
                    .Where(w => w.c.c.ContactTypeId == contactTypeId )
                    .Select(s => new Contact
                    {
                        ID = s.c.c.ID,
                        ContactTypeId = s.c.c.ContactTypeId,
                        ContactTypeInfo = s.c.ct,
                        CreatedBy = s.c.c.CreatedBy,
                        CreatedDate = s.c.c.CreatedDate,
                        Email = s.c.c.Email,
                        FirstName = s.c.c.FirstName,
                        LastName = s.c.c.LastName,
                        LocationId = s.c.c.LocationId,
                        LocationInfo = s.l
                    }).ToListAsync();
                return result;
            }
        }

    }
}
