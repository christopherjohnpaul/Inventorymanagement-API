using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IExcemptionsRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAllByTemplateIdAsyn(long id);
    }
}
