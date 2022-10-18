using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IOrderTemplateProductsRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAllByTemplateIdAsync(long id);
        Task<IList<T>> GetAllByProductIdAsync(long orderTemplateId, List<long> productIdList);
        Task<IList<T>> GetAllBySupplierIdAndTemplateIdAsync(long orderTemplateId, long supplierId);
        Task<bool> SaveProductQuantity(long id, double quantity, long createdBy);
        Task<bool> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy);
        Task<bool> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy);
        Task<bool> EnableDisable(long id, long supplierId, bool enable, long createdBy);
    }
}
