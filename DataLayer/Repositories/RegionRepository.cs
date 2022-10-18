using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class RegionRepository : CURDRepository<Region>, IRegionRepository<Region>
    {
    }
}
