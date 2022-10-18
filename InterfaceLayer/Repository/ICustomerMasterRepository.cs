using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface ICustomerMasterRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
