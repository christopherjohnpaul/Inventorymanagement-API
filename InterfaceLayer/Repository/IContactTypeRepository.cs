using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface IContactTypeRepository<T> : IBaseRepository<T> where T : class
    {
    }
}
