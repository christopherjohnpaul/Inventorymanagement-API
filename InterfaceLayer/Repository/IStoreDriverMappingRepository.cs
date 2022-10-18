using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface IStoreDriverMappingRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
