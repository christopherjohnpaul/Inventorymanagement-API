using InterfaceLayer.Base;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Business
{
    public interface IOrderTemplateProductsLogic<T> : IBaseBusiness<T> where T : class
    {
        Task<Result<List<T>>> GetAllByTemplateIdAsyn(long id);
        Task<Result<T>> PostTemplateProducts(List<OrderTemplateProducts> orderTemplateProducts);
        Task<Result<List<List<string>>>> GenerateOrderTemplateProducts(long orderTemplateId, long supplierId);
        Task<Result<T>> AddProducts(AddProducts entity);
        Task<Result<T>> SaveProductQuantity(long id, double quantity, long createdBy);
        Task<Result<T>> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy);
        Task<Result<T>> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy);
        Task<Result<T>> EnableDisable(long id, long supplierId, bool enable, long createdBy);
    }
}
