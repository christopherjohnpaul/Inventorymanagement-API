using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryCustomerRepository : CURDRepository<CategoryCustomer>, ICategoryCustomerRespository<CategoryCustomer>
    {
        public async Task<IList<CategoryCustomer>> FindAllByCategoryAsync(long categoryId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryCustomer
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.CustomerMaster, cm => cm.cc.CustomerMasterId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.CategoryId == categoryId)
                    .Select(s => new CategoryCustomer
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        CustomerMasterId = s.cm.cc.CustomerMasterId,
                        CategoryInfo = s.cm.ct,
                        CustomerMasterInfo = s.tem
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }

        public override async Task<IList<CategoryCustomer>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryCustomer
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.CustomerMaster, cm => cm.cc.CustomerMasterId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.IsActive == true)
                    .Select(s => new CategoryCustomer
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        CustomerMasterId = s.cm.cc.CustomerMasterId,
                        CategoryInfo = s.cm.ct,
                        CustomerMasterInfo = s.tem
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }


        public override async Task<CategoryCustomer> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryCustomer
                     .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                     .Join(context.CustomerMaster, cm => cm.cc.CustomerMasterId, tem => tem.ID, (cm, tem) => new { cm, tem })

                     .Where(w => w.cm.cc.ID == id)
                     .Select(s => new CategoryCustomer
                     {
                         ID = s.cm.cc.ID,
                         IsActive = s.cm.cc.IsActive,
                         CreatedBy = s.cm.cc.CreatedBy,
                         CreatedDate = s.cm.cc.CreatedDate,
                         ModifiedBy = s.cm.cc.ModifiedBy,
                         ModifiedDate = s.cm.cc.ModifiedDate,
                         CategoryId = s.cm.cc.CategoryId,
                         CustomerMasterId = s.cm.cc.CustomerMasterId,
                         CategoryInfo = s.cm.ct,
                         CustomerMasterInfo = s.tem
                     }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
