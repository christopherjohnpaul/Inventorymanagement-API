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
    public class ContactLogic<T> : BaseBusiness<T>, IContactLogic<T> where T : Contact
    {

        private readonly IContactRepository<Contact> repository;
        public ContactLogic() : base((IBaseRepository<T>)new ContactRepository())
        {
            repository = new ContactRepository();
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
