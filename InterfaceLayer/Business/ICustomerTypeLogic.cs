using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface ICustomerTypeLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
