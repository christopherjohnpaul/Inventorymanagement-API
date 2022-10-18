using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class LocationRepository : CURDRepository<Location>, ILocationRepository<Location>
    {
    }
}
