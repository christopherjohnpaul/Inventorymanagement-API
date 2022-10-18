using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryProductRepository : CURDRepository<CategoryProduct>, ICategoryProductRepository<CategoryProduct>
    {
        public async Task<IList<CategoryProduct>> FindAllByCategoryAsync(long categoryId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryProduct
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.ProductInformation, cm => cm.cc.ProductId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.CategoryId == categoryId)
                    .Select(s => new CategoryProduct
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        ProductId = s.cm.cc.ProductId,
                        CategoryInfo = s.cm.ct,
                        ProductInfo = s.tem,
                        ArticleNumber = s.cm.cc.ArticleNumber,
                        UnitPrice = s.cm.cc.UnitPrice
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }
        public override async Task<IList<CategoryProduct>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryProduct
                    .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                    .Join(context.ProductInformation, cm => cm.cc.ProductId, tem => tem.ID, (cm, tem) => new { cm, tem })

                    .Where(w => w.cm.cc.IsActive == true)
                    .Select(s => new CategoryProduct
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        ProductId = s.cm.cc.ProductId,
                        CategoryInfo = s.cm.ct,
                        ProductInfo = s.tem,
                        ArticleNumber = s.cm.cc.ArticleNumber,
                        UnitPrice = s.cm.cc.UnitPrice
                    }).OrderByDescending(o => o.ID).ToListAsync();
                return result;
            }
        }
        public override async Task<CategoryProduct> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.CategoryProduct
                     .Join(context.Category, cc => cc.CategoryId, ct => ct.ID, (cc, ct) => new { cc, ct })
                     .Join(context.ProductInformation, cm => cm.cc.ProductId, tem => tem.ID, (cm, tem) => new { cm, tem })

                      .Where(w => w.cm.cc.ID == id)
                    .Select(s => new CategoryProduct
                    {
                        ID = s.cm.cc.ID,
                        IsActive = s.cm.cc.IsActive,
                        CreatedBy = s.cm.cc.CreatedBy,
                        CreatedDate = s.cm.cc.CreatedDate,
                        ModifiedBy = s.cm.cc.ModifiedBy,
                        ModifiedDate = s.cm.cc.ModifiedDate,
                        CategoryId = s.cm.cc.CategoryId,
                        ProductId = s.cm.cc.ProductId,
                        CategoryInfo = s.cm.ct,
                        ProductInfo = s.tem,
                        ArticleNumber = s.cm.cc.ArticleNumber,
                        UnitPrice = s.cm.cc.UnitPrice
                    }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
