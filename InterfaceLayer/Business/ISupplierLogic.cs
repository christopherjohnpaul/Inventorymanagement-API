using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface ISupplierLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
