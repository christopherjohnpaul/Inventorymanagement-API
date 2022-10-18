using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;

namespace BusinessLayer
{
    public class CategoryLogic<T> : BaseBusiness<T>, ICategoryLogic<T> where T : Category
    {

        private readonly ICategoryRespository<Category> repository;
        public CategoryLogic():base((IBaseRepository<T>)new CategoryRepository())
        {
            repository = new CategoryRepository();
        }

    }
}