using InterfaceLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ExcemptionsRepository : CURDRepository<Excemptions>, IExcemptionsRepository<Excemptions>
    {
        public async Task<IList<Excemptions>> GetAllByTemplateIdAsyn(long id)
        {
            using (var context = new InventoryMnagementDBContext(options.DatabaseOptions))
            {
                var result = await context.Excemptions
                        .Where(w => w.OrderTemplateId == id)
                        .Select
                        (s => new Excemptions
                        {
                            ID = s.ID,
                            CreatedBy = s.CreatedBy,
                            CreatedDate = s.CreatedDate,
                            IsActive = s.IsActive,
                            ModifiedBy = s.ModifiedBy,
                            ModifiedDate = s.ModifiedDate,
                            OrderTemplateId = s.OrderTemplateId,
                            FromDate=s.FromDate,
                            MultiplyOders=s.MultiplyOders,
                            ToDate=s.ToDate

                        }).ToListAsync();
                return result;
            }
        }
    }
}
