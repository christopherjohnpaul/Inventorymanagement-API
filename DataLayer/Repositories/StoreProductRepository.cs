using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoreProductRepository : CURDRepository<StoreProduct>, IStoreProductRepository<StoreProduct>
    {
        //public override async Task<StoreProduct> CreateAsync(StoreProduct entity)
        //{
        //    using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
        //    {
        //        await context.AddAsync<StoreProduct>(entity);
        //        await context.SaveChangesAsync();

        //        List<StoreInfo> storeList = await context.StoreInfo.Where(w => entity.Group.ToUpper() != "EMPTY GROUP"
        //        && w.Group.ToUpper() == entity.Group.ToUpper() && w.ID != entity.StoreId).ToListAsync();
        //        if (storeList.Count > 0)
        //        {
        //            storeList.ForEach(st =>
        //            {
        //                entity.StoreId = st.ID;
        //                context.AddAsync<StoreProduct>(entity);
        //                context.SaveChangesAsync();
        //            });
        //        }

        //        return entity;
        //    }
        //}
        public override async Task<IList<StoreProduct>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.StoreProduct
                    .Join(context.StoreInfo, pcu => pcu.StoreId, c => c.ID, (pcu, c) => new { pcu, c })
                    .Join(context.ProductInformation, pcup => pcup.pcu.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                    .Where(w => w.pcup.pcu.IsActive == true)
                    .Select
                    (s => new StoreProduct
                    {
                        ID = s.pcup.pcu.ID,
                        StoreId = s.pcup.pcu.StoreId,
                        StoreDetailsInfo = s.pcup.c,
                        ProductId = s.pi.ID,
                        ProductInfo = s.pi,
                        ArticleNumber = s.pcup.pcu.ArticleNumber,
                        Description = s.pcup.pcu.Description,
                        CreatedBy = s.pcup.pcu.CreatedBy,
                        CreatedDate = s.pcup.pcu.CreatedDate,
                        //Group = s.pcup.c.Group,
                        IsActive = s.pcup.pcu.IsActive,
                        ModifiedBy = s.pcup.pcu.ModifiedBy,
                        ModifiedDate = s.pcup.pcu.ModifiedDate
                    }).ToListAsync();
                return result;
            }
        }

        public async Task<IList<StoreProduct>> GetAllByStoreId(long id)
        {
            try
            {
                using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
                {
                    var result = await context.StoreProduct
                        .Join(context.StoreInfo, pcu => pcu.StoreId, c => c.ID, (pcu, c) => new { pcu, c })
                        .Join(context.ProductInformation, pcup => pcup.pcu.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                        .Where(w => w.pcup.pcu.StoreId == id)
                        .Select
                        (s => new StoreProduct
                        {
                            ID = s.pcup.pcu.ID,
                            StoreId = s.pcup.pcu.StoreId,
                            StoreDetailsInfo = s.pcup.c,
                            ProductId = s.pi.ID,
                            ProductInfo = s.pi,
                            ArticleNumber = s.pcup.pcu.ArticleNumber,
                            Description = s.pcup.pcu.Description,
                            CreatedBy = s.pcup.pcu.CreatedBy,
                            CreatedDate = s.pcup.pcu.CreatedDate,
                            IsActive = s.pcup.pcu.IsActive,
                            ModifiedBy = s.pcup.pcu.ModifiedBy,
                          //  Group = s.pcup.c.Group,
                            ModifiedDate = s.pcup.pcu.ModifiedDate
                        }).ToListAsync();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task<StoreProduct> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.StoreProduct
                   .Join(context.StoreInfo, pcu => pcu.StoreId, c => c.ID, (pcu, c) => new { pcu, c })
                    .Join(context.ProductInformation, pcup => pcup.pcu.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                    .Where(w => w.pcup.pcu.ID == id)
                    .Select
                    (s => new StoreProduct
                    {
                        ID = s.pcup.pcu.ID,
                        StoreId = s.pcup.pcu.StoreId,
                        StoreDetailsInfo = s.pcup.c,
                        ProductId = s.pi.ID,
                        ProductInfo = s.pi,
                        ArticleNumber = s.pcup.pcu.ArticleNumber,
                        Description = s.pcup.pcu.Description,
                        CreatedBy = s.pcup.pcu.CreatedBy,
                        CreatedDate = s.pcup.pcu.CreatedDate,
                        IsActive = s.pcup.pcu.IsActive,
                       // Group = s.pcup.c.Group,
                        ModifiedBy = s.pcup.pcu.ModifiedBy,
                        ModifiedDate = s.pcup.pcu.ModifiedDate
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }
    }
}
