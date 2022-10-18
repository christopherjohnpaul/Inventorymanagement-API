using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OrderTemplateRepository : CURDRepository<OrderTemplate>, IOrderTemplateRepository<OrderTemplate>
    {
        public override async Task<IList<OrderTemplate>> FindAllAsync()
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var regionList = await context.Region.Where(w => w.IsActive == true).ToListAsync();
                var result = await context.OrderTemplate
                    //.Join(context.Region, ord => ord.RegionId, rg => rg.ID, (ord, rg) => new { ord, rg })
                    //.Where(w => w.ord.IsActive == true && !string.IsNullOrEmpty(w.ord.Name.Trim()))
                    .Select(s => new OrderTemplate
                    {
                        ID = s.ID,
                        IsActive = s.IsActive,
                        CreatedBy = s.CreatedBy,
                        CreatedDate = s.CreatedDate,
                        ModifiedBy = s.ModifiedBy,
                        ModifiedDate = s.ModifiedDate,
                        TimeOfDelivery = s.TimeOfDelivery,
                        DriverId = s.DriverId,
                        Name = s.Name,
                        RegionId = s.RegionId,
                        DeactivateExcemptions = s.DeactivateExcemptions,
                        //RegionInfo = s.RegionId > 0 ? regionList.Find(r => r.ID == s.RegionId) : null,
                        DayOfWeek = s.DayOfWeek
                    }).OrderByDescending(o => o.ID).ToListAsync();

                result.ForEach(r =>
                {
                    r.RegionInfo = r.RegionId > 0 ? regionList.Find(reg => reg.ID == r.RegionId) : new Region() { Name = "Not Selected" };
                });
                return result;
            }
        }

        public override async Task<OrderTemplate> FindAsync(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var productList = await context.Set<OrderTemplateProducts>().Where(w => w.OrderTemplateId == id).ToListAsync();
                var excemptionsList = await context.Set<Excemptions>().Where(w => w.OrderTemplateId == id).ToListAsync();
                var result = await context.OrderTemplate
                   .Where(w => w.IsActive == true && w.ID == id)
                   .Select(s => new OrderTemplate
                   {
                       ID = s.ID,
                       IsActive = s.IsActive,
                       CreatedBy = s.CreatedBy,
                       CreatedDate = s.CreatedDate,
                       ModifiedBy = s.ModifiedBy,
                       ModifiedDate = s.ModifiedDate,
                       TimeOfDelivery = s.TimeOfDelivery,
                       Name = s.Name,
                       RegionId = s.RegionId,
                       DriverId = s.DriverId,
                       DeactivateExcemptions = s.DeactivateExcemptions,
                       ExcemptionList = excemptionsList,
                       ProductList = productList,
                       DayOfWeek = s.DayOfWeek
                   }).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
