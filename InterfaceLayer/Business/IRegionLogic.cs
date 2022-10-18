using InterfaceLayer.Base;

namespace InterfaceLayer.Business
{
    public interface IRegionLogic<T> : IBaseBusiness<T> where T : class
    {
    }
}
