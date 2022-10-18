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
    public class OrderLogic<T> : BaseBusiness<T>, IOrderLogic<T> where T : Order
    {

        private readonly IOrderRepository<Order> repository;
        private readonly IOrderTemplateRepository<OrderTemplate> orderTemplateRepository;
        private readonly IOrderProductsRepository<OrderProducts> orderProductsRepository;
        private readonly IOrderTemplateProductsRepository<OrderTemplateProducts> orderTemplateProductsRepository;
        private readonly IExcemptionsRepository<Excemptions> excemptionsRepository;
        private readonly IRunLevelRepository<RunLevel> runLevelRepository;
        public OrderLogic() : base((IBaseRepository<T>)new OrderRepository())
        {
            repository = new OrderRepository();
            orderTemplateRepository = new OrderTemplateRepository();
            orderProductsRepository = new OrderProductsRepository();
            orderTemplateProductsRepository = new OrderTemplateProductsRepository();
            excemptionsRepository = new ExcemptionsRepository();
            runLevelRepository = new RunLevelRepository();
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
        public async Task<Result<T>> FinalizeOrder(long id, long createdBy)
        {
            Result<T> result = new();
            try
            {
                result.Success = await repository.FinalizeOrder(id, createdBy);
                result.Data = null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> RunGenerated(long id, long createdBy)
        {
            Result<T> result = new();
            try
            {
                result.Success = await repository.RunGenerated(id, createdBy);
                result.Data = null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> MailSendToSupplier(long id, long createdBy)
        {
            Result<T> result = new();
            try
            {
                result.Success = await repository.MailSendToSupplier(id, createdBy);
                result.Data = null;
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
            var productList = await orderProductsRepository.FindAllAsync(prd => prd.OrderId == id);
            var runList = await runLevelRepository.FindAllByOrderIdAsync(id);
            productList.ToList().ForEach(prd =>
            {
                orderProductsRepository.Delete(prd);
            });
            runList.ToList().ForEach(run =>
            {
                runLevelRepository.Delete(run);
            });
            return true;
        }

        public async Task<Result<T>> GenerateOrder(long createdBy)
        {
            Result<T> result = new();
            try
            {
                await GenerateOrderData(createdBy);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        private void GenerateExceptionMessage(Result<T> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }

        private async Task<T> GenerateOrderData(long createdBy)
        {
            DateTime today = DateTime.Now;
            var dayList = DateTimeHelper.GetDayOfWeekList();

            // generating order for next 7 days
            for (int i = 1; i <= 7; i++)
            {
                // fetch next day
                today = today.AddDays(1);

                // fetch order template with dayofweek of today (calculated above)
                var templatesList = orderTemplateRepository.FindAll(temp => temp.Name != string.Empty && temp.IsActive == true && temp.DayOfWeek == DateTimeHelper.GetDay(today)).ToList();

                if (templatesList.Count > 0)
                {
                    // generate order
                    GenerateOrderData(templatesList, today, createdBy);
                }
            }

            return null;
        }

        private void GenerateOrderData(List<OrderTemplate> templatesList, DateTime today, long createdBy)
        {
            templatesList.ForEach(async template =>
            {
                // create order first
                Order order = await CreateOrder(template, createdBy, today);

                if (order != null)
                {
                    // fetch the excemptions for the given day
                    Excemptions exemption = excemptionsRepository.FindAll(ex => ex.OrderTemplateId == template.ID && ex.FromDate <= today && ex.ToDate >= today).FirstOrDefault();
                    double multiplier = 0;
                    if (exemption != null && exemption.ID > 0)
                    {
                        multiplier = exemption.MultiplyOders;
                    }

                    //find all products
                    orderTemplateProductsRepository.FindAll(temp => temp.OrderTemplateId == template.ID && temp.IsActive == true).ToList().ForEach(item =>
                    {
                        var product = orderProductsRepository.Find(pr => pr.OrderId == order.ID && pr.TemplateId == template.ID &&
                          pr.ProductId == item.ProductId && pr.StoreId == item.StoreId && pr.SupplierId == item.SupplierId);

                        if (product == null)
                            orderProductsRepository.CreateAsync(new OrderProducts()
                            {
                                IsActive = true,
                                CreatedBy = createdBy,
                                ModifiedBy = createdBy,
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                OrderId = order.ID,
                                ProductId = item.ProductId,
                                Quantity = multiplier != 0 ? ((int)Math.Ceiling(item.Quantity + (item.Quantity * multiplier))) : item.Quantity,
                                SalesDay = item.SalesDay,
                                SequenceNumber = item.SequenceNumber,
                                StoreId = item.StoreId,
                                SupplierId = item.SupplierId,
                                TemplateId = template.ID
                            });
                    });
                }
            });
        }

        private async Task<Order> CreateOrder(OrderTemplate template, long createdBy, DateTime today)
        {
            bool exists = false;
            List<Order> orderList = repository.FindAll(ord => ord.OrderTemplateId == template.ID).ToList();
            //if (order != null && !order.OrderDay.ToShortDateString().Equals(today.ToShortDateString()))
            //    order == nu

            exists = orderList.Exists(ord => ord.OrderDay.ToShortDateString() == today.ToShortDateString());

            if (!exists)
            {
                Order order = new()
                {
                    IsActive = true,
                    CreatedBy = createdBy,
                    ModifiedBy = createdBy,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    DriverId = template.DriverId,
                    OrderDay = today,
                    OrderTemplateId = template.ID,
                    TimeOfDelivery = template.TimeOfDelivery,
                    // IsOrderFinalized = true
                };

                return await repository.CreateAsync(order);
            }
            else
                return null;
        }
    }
}
