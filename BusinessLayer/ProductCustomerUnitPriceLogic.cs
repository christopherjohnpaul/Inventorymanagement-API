using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class ProductCustomerUnitPriceLogic<T> : BaseBusiness<T>, IProductCustomerUnitPriceLogic<T> where T : ProductCustomerUnitPrice
    {

        private readonly IProductCustomerUnitPriceRepository<ProductCustomerUnitPrice> repository;
        public ProductCustomerUnitPriceLogic() : base((IBaseRepository<T>)new ProductCustomerUnitPriceRepository())
        {
            repository = new ProductCustomerUnitPriceRepository();
        }
    }
}
