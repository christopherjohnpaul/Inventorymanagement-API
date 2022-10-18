using InterfaceLayer.Base;
using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductCustomerUnitPriceRepository : CURDRepository<ProductCustomerUnitPrice>, IProductCustomerUnitPriceRepository<ProductCustomerUnitPrice>
    {
        public override async Task<IList<ProductCustomerUnitPrice>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.ProductCustomerUnitPrice
                    .Join(context.CustomerMaster, pcu => pcu.CustomerMasterId, c => c.ID, (pcu, c) => new { pcu, c })
                    .Join(context.ProductInformation, pcup => pcup.pcu.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                    .Where(w => w.pcup.pcu.IsActive == true)
                    .Select
                    (s => new ProductCustomerUnitPrice
                    {
                        ID = s.pcup.pcu.ID,
                        CustomerMasterId = s.pcup.pcu.CustomerMasterId,
                        CustomerMasterInfo = s.pcup.c,
                        ProductId = s.pi.ID,
                        ProductInfo = s.pi,
                        UnitPrice = s.pcup.pcu.UnitPrice,
                        EffectiveFromDate = s.pcup.pcu.EffectiveFromDate,
                        EffectiveTillDate = s.pcup.pcu.EffectiveTillDate,
                        CreatedBy = s.pcup.pcu.CreatedBy,
                        CreatedDate = s.pcup.pcu.CreatedDate,
                        IsActive = s.pcup.pcu.IsActive,
                        ModifiedBy = s.pcup.pcu.ModifiedBy,
                        ModifiedDate = s.pcup.pcu.ModifiedDate
                    }).ToListAsync();
                return result;
            }
        }

        public override async Task<ProductCustomerUnitPrice> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var obj = await context.ProductCustomerUnitPrice
                    .Join(context.CustomerMaster, pcu => pcu.CustomerMasterId, c => c.ID, (pcu, c) => new { pcu, c })
                    .Join(context.ProductInformation, pcup => pcup.pcu.ProductId, pi => pi.ID, (pcup, pi) => new { pcup, pi })
                    .Where(w => w.pcup.pcu.ID == id)
                    .Select
                    (s => new ProductCustomerUnitPrice
                    {
                        ID = s.pcup.pcu.ID,
                        CustomerMasterId = s.pcup.pcu.CustomerMasterId,
                        CustomerMasterInfo = s.pcup.c,
                        ProductId = s.pi.ID,
                        ProductInfo = s.pi,
                        UnitPrice = s.pcup.pcu.UnitPrice,
                        EffectiveFromDate = s.pcup.pcu.EffectiveFromDate,
                        EffectiveTillDate = s.pcup.pcu.EffectiveTillDate,
                        CreatedBy = s.pcup.pcu.CreatedBy,
                        CreatedDate = s.pcup.pcu.CreatedDate,
                        IsActive = s.pcup.pcu.IsActive,
                        ModifiedBy = s.pcup.pcu.ModifiedBy,
                        ModifiedDate = s.pcup.pcu.ModifiedDate
                    }).FirstOrDefaultAsync();
                return obj;
            }
        }

    }
}
