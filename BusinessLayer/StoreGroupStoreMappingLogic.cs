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
    public class StoreGroupStoreMappingLogic<T> : BaseBusiness<T>, IStoreGroupStoreMappingLogic<T> where T : StoreGroupStoreMapping
    {
        private readonly IStoreGroupStoreMappingRepository<StoreGroupStoreMapping> repository;
        public StoreGroupStoreMappingLogic() : base((IBaseRepository<T>)new StoreGroupStoreMappingRepository())
        {
            repository = new StoreGroupStoreMappingRepository();
        }
        public async Task<Result<List<T>>> FindAllByStoreGroupIdAsync(long storeGroupeId)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.FindAllByStoreGroupIdAsync(storeGroupeId);
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