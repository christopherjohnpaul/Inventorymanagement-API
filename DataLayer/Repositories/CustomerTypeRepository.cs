using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class CustomerTypeRepository : CURDRepository<CustomerType>, ICustomerTypeRepository<CustomerType>
    {
    }
}
