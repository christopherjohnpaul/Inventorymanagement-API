using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface IProductLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
