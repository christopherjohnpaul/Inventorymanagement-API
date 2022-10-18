using DataLayer.Repositories;
using InterfaceLayer;
using InterfaceLayer.Base;
using InterfaceLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserLogic<T> : BaseBusiness<T>, IUserLogic<T> where T : UserInfo
    {
        private readonly IUserRepository<UserInfo> repository;

        public UserLogic() : base((IBaseRepository<T>)new UserRepository())
        {
            repository = new UserRepository();
        }
        public async Task<Result<T>> LoginAsync(string email, string password, bool isGoogleLogin)
        {
            Result<T> result = new();
            try
            {
                result.Data = (T)await repository.LoginAsync(email, password, isGoogleLogin);
                result.Success = result.Data != null ? true : false;
                result.Message = result.Data != null ? ResultMessages.UserLoggedIn : ResultMessages.UserNotFound;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        public async Task<Result<T>> RegisterUserAsync(UserInfo user)
        {
            Result<T> result = new();
            try
            {
                result.Data = (T)await repository.RegisterUserAsync(user);
                result.Success = result.Data != null ? true : false;
                result.Message = result.Data != null ? ResultMessages.UserRegistrationSuccess : ResultMessages.UserRegistrationFailed;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<List<T>>> GetAllByContactTypeAsync(long contactTypeId)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.GetAllByContactTypeAsync(contactTypeId);
                result.Success = result.Data != null ? true : false;
                result.Message = result.Data != null ? ResultMessages.Success : ResultMessages.Failed;
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
