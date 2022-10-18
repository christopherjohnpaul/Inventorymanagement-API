using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class ProductLogic<T> : BaseBusiness<T>, IProductLogic<T> where T : ProductInformation
    {

        private readonly IProductRepository<ProductInformation> repository;
        public ProductLogic() : base((IBaseRepository<T>)new ProductRepository())
        {
            repository = new ProductRepository();
        }

    }
}
