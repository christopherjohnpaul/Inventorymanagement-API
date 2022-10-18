using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IOrderTemplateLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<KeyValuePair<int, string>>>> GetDaysList();
    }
}
