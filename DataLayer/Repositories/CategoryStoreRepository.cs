using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryStoreRepository : CURDRepository<CategoryStore>, ICategoryStoreRepository<CategoryStore>
    {
        public async Task<IList<CategoryStore>> FindAllByCategoryAsync(long categoryId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryStore
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.StoreInfo, cm => cm.cc.StoreId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.CategoryId == categoryId)
                    .Select(s => new CategoryStore
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        StoreId = s.cm.cc.StoreId,
                        CategoryInfo = s.cm.ct,
                        StoreInfoDetails = s.tem
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }

        public override async Task<IList<CategoryStore>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryStore
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.StoreInfo, cm => cm.cc.StoreId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.IsActive == true)
                    .Select(s => new CategoryStore
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        StoreId = s.cm.cc.StoreId,
                        CategoryInfo = s.cm.ct,
                        StoreInfoDetails = s.tem
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }


        public override async Task<CategoryStore> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryStore
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.StoreInfo, cm => cm.cc.StoreId, tem => tem.ID, (cm, tem) => new { cm, tem })

                     .Where(w => w.cm.cc.ID == id)
                     .Select(s => new CategoryStore
                     {
                         ID = s.cm.cc.ID,
                         IsActive = s.cm.cc.IsActive,
                         CreatedBy = s.cm.cc.CreatedBy,
                         CreatedDate = s.cm.cc.CreatedDate,
                         ModifiedBy = s.cm.cc.ModifiedBy,
                         ModifiedDate = s.cm.cc.ModifiedDate,
                         CategoryId = s.cm.cc.CategoryId,
                         StoreId = s.cm.cc.StoreId,
                         CategoryInfo = s.cm.ct,
                         StoreInfoDetails = s.tem
                     }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
