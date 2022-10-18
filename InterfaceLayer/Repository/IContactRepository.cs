using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IContactRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<Contact>> GetAllByContactTypeAsync(long contactTypeId);
    }
}
