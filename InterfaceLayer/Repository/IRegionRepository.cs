using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface IRegionRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
