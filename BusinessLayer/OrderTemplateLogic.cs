using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;
using ModelLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderTemplateLogic<T> : BaseBusiness<T>, IOrderTemplateLogic<T> where T : OrderTemplate
    {

        private readonly IOrderTemplateRepository<OrderTemplate> repository;
        private readonly IOrderTemplateProductsRepository<OrderTemplateProducts> orderTemplateProductsRepository;
        private readonly IExcemptionsRepository<Excemptions> excemptionsRepository;
        public OrderTemplateLogic() : base((IBaseRepository<T>)new OrderTemplateRepository())
        {
            repository = new OrderTemplateRepository();
            orderTemplateProductsRepository = new OrderTemplateProductsRepository();
            excemptionsRepository = new ExcemptionsRepository();
        }
        public async override Task<Result<T>> DeleteAsync(long id)
        {
            Result<T> result = new();
            try
            {
                await DeleteDataAsync(id);
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

        private async Task<bool> DeleteDataAsync(long id)
        {
            await base.curdRepository.DeleteAsync(id);
            var productList = await orderTemplateProductsRepository.FindAllAsync(prd => prd.OrderTemplateId == id);

            productList.ToList().ForEach(prd =>
            {
                orderTemplateProductsRepository.Delete(prd);
            });

            var excemptionList = await excemptionsRepository.FindAllAsync(ex => ex.OrderTemplateId == id);

            excemptionList.ToList().ForEach(ex =>
            {
                excemptionsRepository.Delete(ex);
            });
            return true;
        }

        public async Task<Result<List<KeyValuePair<int, string>>>> GetDaysList()
        {
            Result<List<KeyValuePair<int, string>>> result = new();
            try
            {
                result.Data = DateTimeHelper.GetDayOfWeekList();
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        private void GenerateExceptionMessage(Result<List<KeyValuePair<int, string>>> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }

        private void GenerateExceptionMessage(Result<T> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }
    }
}
