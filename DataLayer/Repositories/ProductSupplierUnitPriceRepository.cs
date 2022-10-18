using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductSupplierUnitPriceRepository : CURDRepository<ProductSupplierUnitPrice>, IProductSupplierUnitPriceRepository<ProductSupplierUnitPrice>
    {
        public override async Task<IList<ProductSupplierUnitPrice>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.ProductSupplierUnitPrice
                    .Join(context.ProductInformation, ps => ps.ProductId, p => p.ID, (ps, p) => new { ps, p })
                    .Join(context.Supplier, ps => ps.ps.SupplierId, s => s.ID, (ps, s) => new { ps, s })
                    .Where(w => w.ps.ps.IsActive == true)
                    .Select(s => new ProductSupplierUnitPrice
                    {
                        ID = s.ps.ps.ID,
                        ProductInfo = s.ps.p,
                        ProductId = s.ps.ps.ProductId,
                        CreatedBy = s.ps.ps.CreatedBy,
                        SupplierId = s.ps.ps.SupplierId,
                        SupplierInfo = s.s,
                        CreatedDate = s.ps.ps.CreatedDate,
                        EffectiveFromDate = s.ps.ps.EffectiveFromDate,
                        EffectiveTillDate = s.ps.ps.EffectiveTillDate,
                        IsActive = s.ps.ps.IsActive,
                        ModifiedBy = s.ps.ps.ModifiedBy,
                        ModifiedDate = s.ps.ps.ModifiedDate,
                        UnitPrice = s.ps.ps.UnitPrice
                    }).ToListAsync();
                return result;
            }
        }
        public  async Task<IList<ProductSupplierUnitPrice>> FindAllBySupplierIdAsync(long supplierId)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.ProductSupplierUnitPrice
                    .Join(context.ProductInformation, ps => ps.ProductId, p => p.ID, (ps, p) => new { ps, p })
                    .Join(context.Supplier, ps => ps.ps.SupplierId, s => s.ID, (ps, s) => new { ps, s })
                    .Where(w => w.ps.ps.SupplierId == supplierId)
                    .Select(s => new ProductSupplierUnitPrice
                    {
                        ID = s.ps.ps.ID,
                        ProductInfo = s.ps.p,
                        ProductId = s.ps.ps.ProductId,
                        CreatedBy = s.ps.ps.CreatedBy,
                        SupplierId = s.ps.ps.SupplierId,
                        SupplierInfo = s.s,
                        CreatedDate = s.ps.ps.CreatedDate,
                        EffectiveFromDate = s.ps.ps.EffectiveFromDate,
                        EffectiveTillDate = s.ps.ps.EffectiveTillDate,
                        IsActive = s.ps.ps.IsActive,
                        ModifiedBy = s.ps.ps.ModifiedBy,
                        ModifiedDate = s.ps.ps.ModifiedDate,
                        UnitPrice = s.ps.ps.UnitPrice
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<ProductSupplierUnitPrice> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.ProductSupplierUnitPrice
                    .Join(context.ProductInformation, ps => ps.ProductId, p => p.ID, (ps, p) => new { ps, p })
                    .Join(context.Supplier, ps => ps.ps.SupplierId, s => s.ID, (ps, s) => new { ps, s })
                    .Where(w => w.ps.ps.ID == id)
                    .Select(s => new ProductSupplierUnitPrice
                    {
                        ID = s.ps.ps.ID,
                        ProductInfo = s.ps.p,
                        ProductId = s.ps.ps.ProductId,
                        CreatedBy = s.ps.ps.CreatedBy,
                        SupplierId = s.ps.ps.SupplierId,
                        SupplierInfo = s.s,
                        CreatedDate = s.ps.ps.CreatedDate,
                        EffectiveFromDate = s.ps.ps.EffectiveFromDate,
                        EffectiveTillDate = s.ps.ps.EffectiveTillDate,
                        IsActive = s.ps.ps.IsActive,
                        ModifiedBy = s.ps.ps.ModifiedBy,
                        ModifiedDate = s.ps.ps.ModifiedDate,
                        UnitPrice = s.ps.ps.UnitPrice
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }
    }
}
