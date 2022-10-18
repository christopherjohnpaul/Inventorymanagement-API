using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class CustomerMasterLogic<T> : BaseBusiness<T>, ICustomerMasterLogic<T> where T : CustomerMaster
    {

        private readonly ICustomerMasterRepository<CustomerMaster> repository;
        public CustomerMasterLogic() : base((IBaseRepository<T>)new CustomerMasterRepository())
        {
            repository = new CustomerMasterRepository();
        }

    }
}
