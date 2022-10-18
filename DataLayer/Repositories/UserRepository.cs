using DataLayer.DBContext;
using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : CURDRepository<UserInfo>, IUserRepository<UserInfo>
    {
        public readonly OptionsBuild options = new();
        public UserRepository()
        {
            options = new OptionsBuild();
        }
        public async Task<UserInfo> LoginAsync(string email, string password, bool isGoogleLogin)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                UserInfo obj = null;
                var contactObj = await context.Contact.FirstOrDefaultAsync(c => c.Email.ToUpper().Equals(email.ToUpper()));
                contactObj.ContactTypeInfo = await context.ContactType.FirstOrDefaultAsync(c => c.ID == contactObj.ContactTypeId);
                if (isGoogleLogin)
                    obj = await context.UserInfo.FirstOrDefaultAsync(a => a.UserName.ToUpper().Equals(email.ToUpper()) && a.IsLoginEnabled);
                else
                    obj = await context.UserInfo.FirstOrDefaultAsync(a => a.UserName.ToUpper().Equals(email.ToUpper()) 
                    && a.Password.ToUpper().Equals(password.ToUpper()) && a.IsLoginEnabled);

                if (obj != null)
                {
                    obj.ContactInfo = contactObj;
                    obj.ContactId = contactObj.ID;
                }
                return obj;
            }
        }

        public async Task<UserInfo> RegisterUserAsync(UserInfo user)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                //var contactObj = await context.Contact.AddAsync(user.ContactInfo);
                //await context.SaveChangesAsync();
                user.ContactId = user.ContactId;
                var userObj = await context.UserInfo.AddAsync(user);
                await context.SaveChangesAsync();
                return userObj.Entity;
            }
        }

        public async Task<IList<UserInfo>> GetAllByContactTypeAsync(long contactTypeId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.UserInfo
                   .Join(context.Contact, u => u.ContactId, c => c.ID, (u, c) => new { u, c })
                    .Join(context.ContactType, c => c.c.ContactTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Location, c => c.c.c.LocationId, l => l.ID, (c, l) => new { c, l })
                    .Where(w => w.c.c.c.ContactTypeId == contactTypeId)
                    .Select(s => new UserInfo
                    {
                        ID = s.c.c.u.ID,
                        ContactId = s.c.c.c.ID,
                        ContactInfo = s.c.c.c,
                        CreatedBy = s.c.c.u.CreatedBy,
                        CreatedDate = s.c.c.u.CreatedDate,
                        ModifiedBy = s.c.c.u.ModifiedBy,
                        ModifiedDate = s.c.c.u.ModifiedDate,
                        IsLoginEnabled = s.c.c.u.IsLoginEnabled
                    }).ToListAsync();
                return obj;
            }
        }
    }
}
