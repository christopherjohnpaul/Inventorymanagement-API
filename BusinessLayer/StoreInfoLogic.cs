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
    public class StoreInfoLogic<T> : BaseBusiness<T>, IStoreInfoLogic<T> where T : StoreInfo
    {

        private readonly IStoreInfoRepository<StoreInfo> repository;
        public StoreInfoLogic() : base((IBaseRepository<T>)new StoreInfoRepository())
        {
            repository = new StoreInfoRepository();
        }

        public async Task<Result<List<T>>> GetAllBySupplierId(long id)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.GetAllBySupplierId(id);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        private static void GenerateExceptionMessage(Result<T> result, Exception ex)
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
