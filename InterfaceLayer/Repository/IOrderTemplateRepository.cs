using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface IOrderTemplateRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
