using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IStoreInfoLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<T>>> GetAllBySupplierId(long id);
    }
}
