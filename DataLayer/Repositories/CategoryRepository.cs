using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class CategoryRepository : CURDRepository<Category>, ICategoryRespository<Category>
    {
    }
}
