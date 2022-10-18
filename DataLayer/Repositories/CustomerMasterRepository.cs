using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CustomerMasterRepository : CURDRepository<CustomerMaster>, ICustomerMasterRepository<CustomerMaster>
    {
        public override async Task<IList<CustomerMaster>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CustomerMaster
                    .Join(context.CustomerType, c => c.CustomerTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Contact, c => c.c.ContactId, cn => cn.ID, (c, cn) => new { c, cn })
                    .Where(w => w.c.c.IsActive == true)
                    .Select(s => new CustomerMaster
                    {
                        ID = s.c.c.ID,
                        CustomerTypeId = s.c.c.CustomerTypeId,
                        CreatedDate = s.c.c.CreatedDate,
                        CreatedBy = s.c.c.CreatedBy,
                        CustomerTypeInfo = s.c.ct,
                        ContactInfo = s.cn,
                        ContactId = s.c.c.ContactId,
                        IndividualPrice = s.c.c.IndividualPrice,
                        Name = s.c.c.Name,
                        PriceLevel = s.c.c.PriceLevel,
                        IsActive = s.c.c.IsActive,
                        ModifiedBy = s.c.c.ModifiedBy,
                        ModifiedDate = s.c.c.ModifiedDate
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<CustomerMaster> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CustomerMaster
                    .Join(context.CustomerType, c => c.CustomerTypeId, ct => ct.ID, (c, ct) => new { c, ct })
                    .Join(context.Contact, c => c.c.ContactId, cn => cn.ID, (c, cn) => new { c, cn })
                    .Where(w => w.c.c.ID == id)
                    .Select(s => new CustomerMaster
                    {
                        ID = s.c.c.ID,
                        CustomerTypeId = s.c.c.CustomerTypeId,
                        CreatedDate = s.c.c.CreatedDate,
                        CreatedBy = s.c.c.CreatedBy,
                        CustomerTypeInfo = s.c.ct,
                        ContactInfo = s.cn,
                        ContactId = s.c.c.ContactId,
                        IndividualPrice = s.c.c.IndividualPrice,
                        Name = s.c.c.Name,
                        PriceLevel = s.c.c.PriceLevel,
                        IsActive = s.c.c.IsActive,
                        ModifiedBy = s.c.c.ModifiedBy,
                        ModifiedDate = s.c.c.ModifiedDate
                    }).FirstOrDefaultAsync();
                return result;
            }
        }

    }
}
