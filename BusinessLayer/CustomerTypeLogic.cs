using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class CustomerTypeLogic<T> : BaseBusiness<T>, ICustomerTypeLogic<T> where T : CustomerType
    {

        private readonly ICustomerTypeRepository<CustomerType> repository;
        public CustomerTypeLogic() : base((IBaseRepository<T>)new CustomerTypeRepository())
        {
            repository = new CustomerTypeRepository();
        }

    }
}
