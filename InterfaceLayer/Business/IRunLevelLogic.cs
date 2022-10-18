using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IRunLevelLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<GeneratedRuns>>> FindAllByOrderIdAsync(long orderId);
        Task<Result<T>> GenerateRunAsync(long orderId, long createdBy);
        Task<Result<T>> GenerateAndSendRunMail(long orderId);
    }
}
