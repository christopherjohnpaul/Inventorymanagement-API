using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface ICategoryLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
