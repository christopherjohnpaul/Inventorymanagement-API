using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IContactLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<T>>> GetAllByContactTypeAsync(long contactTypeId);
    }
}
