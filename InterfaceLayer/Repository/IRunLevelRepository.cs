using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IRunLevelRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<RunLevel>> FindAllByOrderIdAsync(long orderId);
    }
}
