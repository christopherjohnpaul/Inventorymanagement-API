using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryCustomerLogic<T> : BaseBusiness<T>, ICategoryCustomerLogic<T> where T : CategoryCustomer
    {

        private readonly ICategoryCustomerRespository<CategoryCustomer> repository;
        public CategoryCustomerLogic() : base((IBaseRepository<T>)new CategoryCustomerRepository())
        {
            repository = new CategoryCustomerRepository();
        }


        public async Task<Result<List<T>>> FindAllByCategoryAsync(long categoryId)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.FindAllByCategoryAsync(categoryId);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        private static void GenerateExceptionMessage(Result<UserInfo> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }
        private static void GenerateExceptionMessage(Result<List<T>> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }

    }
}