using InterfaceLayer.Base;
using ModelLayer;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IOrderLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<T>> GenerateOrder(long createdBy);
        Task<Result<T>> FinalizeOrder(long id, long createdBy);
        Task<Result<T>> RunGenerated(long id, long createdBy);
        Task<Result<T>> MailSendToSupplier(long id, long createdBy);
    }
}
