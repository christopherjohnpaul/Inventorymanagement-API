using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface IProductRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
