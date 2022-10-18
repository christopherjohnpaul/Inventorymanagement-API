using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IOrderProductsRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAllByOrderIdAsyn(long id);
        Task<bool> UpsertByOrderTemplateId(long orderId, long templateId);
        Task<IList<T>> GetAllByProductIdAsync(long orderId, List<long> productIdList);
        Task<IList<T>> GetAllBySupplierIdandOrderIdAsync(long orderId, long supplierId, long templateId);
        Task<bool> SaveProductQuantity(long id, double quantity, long createdBy);
        Task<bool> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy);
        Task<bool> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy);
        Task<bool> EnableDisable(long id, long supplierId, bool enable, long createdBy);
        Task<bool> DeleteByOrderId(long orderId);
    }
}
