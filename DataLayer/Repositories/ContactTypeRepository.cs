using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class ContactTypeRepository : CURDRepository<ContactType>, IContactTypeRepository<ContactType>
    {
    }
}
