using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class LocationLogic<T> : BaseBusiness<T>, ILocationLogic<T> where T : Location
    {

        private readonly ILocationRepository<Location> repository;
        public LocationLogic() : base((IBaseRepository<T>)new LocationRepository())
        {
            repository = new LocationRepository();
        }
    }
}