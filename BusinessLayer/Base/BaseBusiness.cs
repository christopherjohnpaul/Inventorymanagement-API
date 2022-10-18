using InterfaceLayer.Base;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceLayer.Repository
{
    public abstract class BaseBusiness<T> where T : class
    {
        protected IBaseRepository<T> curdRepository;
        public BaseBusiness()
        {
            //   repository = new CURDRepository<T>();
        }
        public BaseBusiness(IBaseRepository<T> ICurdRepository)
        {
            curdRepository = ICurdRepository;
        }
        public async virtual Task<Result<T>> CreateAsync(T entity)
        {
            Result<T> result = new();
            try
            {
                result.Data = await curdRepository.CreateAsync(entity);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async virtual Task<Result<T>> FindAsync(long id)
        {
            Result<T> result = new();
            try
            {
                result.Data = await curdRepository.FindAsync(id);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async virtual Task<Result<List<T>>> FindAllAsync()
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await curdRepository.FindAllAsync();
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async virtual Task<Result<T>> UpdateAsync(T entity, long id)
        {
            Result<T> result = new();
            try
            {
                result.Data = await curdRepository.UpdateAsync(entity, id);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async virtual Task<Result<T>> DeleteAsync(long id)
        {
            Result<T> result = new();
            try
            {
                await curdRepository.DeleteAsync(id);
                result.Data = null;
                result.Success = true;
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
