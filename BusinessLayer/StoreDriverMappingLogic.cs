using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class StoreDriverMappingLogic<T> : BaseBusiness<T>, IStoreDriverMappingLogic<T> where T : StoreDriverMapping
    {

        private readonly IStoreDriverMappingRepository<StoreDriverMapping> repository;
        public StoreDriverMappingLogic()
        {
            base.curdRepository = (IBaseRepository<T>)new StoreDriverMappingRepository();
            repository = new StoreDriverMappingRepository();
        }
    }
}
