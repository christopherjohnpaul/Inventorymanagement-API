using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface ILocationRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
