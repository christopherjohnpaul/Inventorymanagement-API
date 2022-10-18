using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class SupplierLogic<T> : BaseBusiness<T>, ISupplierLogic<T> where T : Supplier
    {

        private readonly ISupplierRepository<Supplier> repository;
        public SupplierLogic() : base((IBaseRepository<T>)new SupplierRepository())
        {
            repository = new SupplierRepository();
        }

    }
}
