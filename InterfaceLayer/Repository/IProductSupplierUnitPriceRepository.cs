using InterfaceLayer.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public interface IProductSupplierUnitPriceRepository<T> : IBaseRepository<T> where T : class
    {
        Task<IList<T>> FindAllBySupplierIdAsync(long supplierId);
    }
}
