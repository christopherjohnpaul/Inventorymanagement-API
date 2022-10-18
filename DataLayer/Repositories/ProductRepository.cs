using InterfaceLayer.Repository;
using ModelLayer;

namespace DataLayer.Repositories
{
    public class ProductRepository : CURDRepository<ProductInformation>, IProductRepository<ProductInformation>
    {
    }
}
