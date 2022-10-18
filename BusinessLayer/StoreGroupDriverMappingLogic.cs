using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class StoreGroupDriverMappingLogic<T> : BaseBusiness<T>, IStoreGroupDriverMappingLogic<T> where T : StoreGroupDriverMapping
    {
        private readonly IStoreGroupDriverMappingRepository<StoreGroupDriverMapping> repository;
        public StoreGroupDriverMappingLogic() : base((IBaseRepository<T>)new StoreGroupDriverMappingRepository())
        {
            repository = new StoreGroupDriverMappingRepository();
        }
    }
}
