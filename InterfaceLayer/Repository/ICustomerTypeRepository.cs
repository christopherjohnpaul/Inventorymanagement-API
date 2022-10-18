using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface ICustomerTypeRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
