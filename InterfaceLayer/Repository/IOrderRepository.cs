using InterfaceLayer.Base;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IOrderRepository<T> : IBaseRepository<T> where T : class
    {
        Task<bool> FinalizeOrder(long id, long createdBy);
        Task<bool> RunGenerated(long id, long createdBy);
        Task<bool> MailSendToSupplier(long id, long createdBy);
    }
}
