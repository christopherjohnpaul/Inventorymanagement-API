using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface ISupplierRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
