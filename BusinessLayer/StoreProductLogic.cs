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
    public class StoreProductLogic<T> : BaseBusiness<T>, IStoreProductLogic<T> where T : StoreProduct
    {

        private readonly IStoreProductRepository<StoreProduct> repository;
        public StoreProductLogic() : base((IBaseRepository<T>)new StoreProductRepository())
        {
            repository = new StoreProductRepository();
        }

        public async Task<Result<List<T>>> GetAllByStoreId(long id)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.GetAllByStoreId(id);
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
