using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class ProductSupplierUnitPriceLogic<T> : BaseBusiness<T>, IProductSupplierUnitPriceLogic<T> where T : ProductSupplierUnitPrice
    {

        private readonly IProductSupplierUnitPriceRepository<ProductSupplierUnitPrice> repository;
        public ProductSupplierUnitPriceLogic() : base((IBaseRepository<T>)new ProductSupplierUnitPriceRepository())
        {
            repository = new ProductSupplierUnitPriceRepository();
        }
    }
}
