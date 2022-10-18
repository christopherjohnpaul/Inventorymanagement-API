using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface ICategoryStoreRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<T>> FindAllByCategoryAsync(long categoryId);
    }
}