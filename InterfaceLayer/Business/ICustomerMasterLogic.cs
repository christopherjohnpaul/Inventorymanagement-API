using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface ICustomerMasterLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
