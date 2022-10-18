using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IStoreInfoRepository<T> : IBaseRepository<T> where T : class
    {
        public Task<IList<T>> GetAllBySupplierId(long id);
    }
}
