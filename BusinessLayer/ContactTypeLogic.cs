using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class ContactTypeLogic<T> : BaseBusiness<T>, IContactTypeLogic<T> where T : ContactType
    {

        private readonly IContactTypeRepository<ContactType> repository;
        public ContactTypeLogic() : base((IBaseRepository<T>)new ContactTypeRepository())
        {
            repository = new ContactTypeRepository();
        }

    }
}
