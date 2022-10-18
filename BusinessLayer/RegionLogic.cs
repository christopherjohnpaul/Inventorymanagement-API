using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class RegionLogic<T> : BaseBusiness<T>, IRegionLogic<T> where T : Region
    {
        private readonly IRegionRepository<Region> repository;
        public RegionLogic() : base((IBaseRepository<T>)new RegionRepository())
        {
            repository = new RegionRepository();
        }
    }
}
