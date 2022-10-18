using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface ILocationLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
