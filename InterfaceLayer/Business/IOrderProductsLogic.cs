using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IOrderProductsLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<T>>> GetAllByOrderIdAsyn(long id);
        Task<bool> UpsertByOrderTemplateId(long orderId, long templateId);
        Task<Result<T>> PostOrderProducts(List<OrderProducts> orderProductsList);
        Task<Result<T>> AddProducts(AddProducts entity);
        Task<Result<T>> SaveProductQuantity(long id, double quantity, long createdBy);
        Task<Result<T>> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy);
        Task<Result<T>> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy);
        Task<Result<T>> EnableDisable(long id, long supplierId, bool enable, long createdBy);
        Task<Result<List<List<string>>>> GenerateOrderProducts(long orderTemplateId, long supplierId, long templateId);
        Task<Result<T>> ChangeOrderTemplate(long orderId, long templateId, long createdBy);
        Task<Result<T>> SendMailToSupplier(long orderId, long supplierId, long templateId);
        Task<Result<T>> SendMailToSuppliersByOrderId(long orderId, long createdBy);
    }
}
