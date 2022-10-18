using InterfaceLayer.Base;

namespace InterfaceLayer.Repository
{
    public interface ICategoryRespository<T> : IBaseRepository<T> where T : class
    {
    }
}
