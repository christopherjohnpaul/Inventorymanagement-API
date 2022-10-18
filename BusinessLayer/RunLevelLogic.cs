using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using ModelLayer.Utility;
using ModelLayer.CustomExceptions;

namespace BusinessLayer
{
    public class RunLevelLogic<T> : BaseBusiness<T>, IRunLevelLogic<T> where T : RunLevel
    {

        private readonly IRunLevelRepository<RunLevel> repository;
        private readonly IOrderProductsRepository<OrderProducts> orderProductsRepository;
        private readonly IOrderRepository<Order> orderRepository;
        private readonly IStoreGroupDriverMappingRepository<StoreGroupDriverMapping> storeGroupDriverRepo;
        private readonly IStoreGroupStoreMappingRepository<StoreGroupStoreMapping> storeGroupStoreRepo;
        public RunLevelLogic() : base((IBaseRepository<T>)new RunLevelRepository())
        {
            repository = new RunLevelRepository();
            orderProductsRepository = new OrderProductsRepository();
            orderRepository = new OrderRepository();
            storeGroupDriverRepo = new StoreGroupDriverMappingRepository();
            storeGroupStoreRepo = new StoreGroupStoreMappingRepository();
        }

        public async Task<Result<List<GeneratedRuns>>> FindAllByOrderIdAsync(long orderId)
        {
            Result<List<GeneratedRuns>> result = new();
            try
            {
                result.Data = await GenerateRunData(orderId);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> GenerateAndSendRunMail(long orderId)
        {
            Result<T> result = new();
            try
            {
                List<GeneratedRuns> data = await GenerateRunData(orderId, true);
                SendRunEmail(data);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        public async Task<Result<T>> GenerateRunAsync(long orderId, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await GenerateRunCycleAsync(orderId, createdBy);
                // result.Data = (List<T>)await repository.FindAllByOrderIdAsync(orderId);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        private void SendRunEmail(List<GeneratedRuns> data)
        {
            data.ForEach(run =>
            {
                var subject = string.Format($"Order - {run.OrderId} - delivery day - {run.OrdeeDate.ToString("MM/dd/yyyy")}");
                var body = run.GenerateHtml();
                var attachment = run.GenerateRunExcel();
                var fileName = string.Format($"Order - {run.OrderId} - delivery day - {run.OrdeeDate.ToString("MM/dd/yyyy")}.xlsx");
                EmailUtility.SendMail(run.DriverEmail, subject, body, attachment, fileName);
            });
        }
        private async Task<List<GeneratedRuns>> GenerateRunData(long orderId, bool includeDataTablet = false)
        {
            Order order = await orderRepository.FindAsync(orderId);
            List<RunLevel> runList = (List<RunLevel>)await repository.FindAllByOrderIdAsync(orderId);
            DataTable dt;
            List<GeneratedRuns> generatedRunList = new();
            GeneratedRuns runs;
            runList.GroupBy(rn => new { rn.RunNumber }).Select(rn => new { RunNumber = rn.Key.RunNumber, RunList = rn.ToList() }).ToList().ForEach(num =>
                  {
                      runs = new();
                      runs.OrdeeDate = order.OrderDay;
                      runs.OrderId = order.ID;
                      runs.RunNumber = num.RunNumber;
                      var driverInfo = num.RunList.FirstOrDefault().DriverInfo.ContactInfo;
                      runs.DriverName = string.Format($"{driverInfo.FirstName} {driverInfo.LastName}");
                      runs.DriverEmail = driverInfo.Email;
                      runs.DriverMobileNumber = driverInfo.MobileNumber;
                      dt = new();
                      GenerateHeader(num.RunList, dt);
                      runs.Total = GenerateBody(num.RunList, dt);
                      runs.RunData = dt.ConvertDtToList();
                      runs.RunDataTable = includeDataTablet ? dt : null;
                      generatedRunList.Add(runs);
                  });
            return generatedRunList;
        }
        private async Task SendEmail(DataSet ds)
        {
            throw new NotImplementedException();
        }
        private double GenerateBody(List<RunLevel> runLevels, DataTable dt)
        {
            double total = 0;
            DataRow row;
            int counter = 1;
            runLevels.GroupBy(rn => new { rn.StoreId, rn.StoreInfo.Name }).Select(s => new { StoreId = s.Key.StoreId, StoreName = s.Key.Name, RunList = s.ToList() })
                .ToList().ForEach(grp =>
              {
                  row = dt.NewRow();
                  row["##"] = grp.StoreName;
                  row["#"] = counter.ToString();
                  grp.RunList.ForEach(rn =>
                  {
                      total += rn.Quantity;
                      row[string.Format($"#Supplier#{rn.SupplierId}#Product#{rn.ProductId}#")] = rn.Quantity;
                  });
                  dt.Rows.Add(row);
                  counter++;
              });
            // Row total
            row = dt.NewRow();
            row["##"] = "Total";
            row["#"] = counter.ToString();
            runLevels.GroupBy(rn => rn.ProductId).Select(s => new { SupplierId = s.FirstOrDefault().SupplierId, ProductId = s.Key, Quantity = s.Sum(item => item.Quantity) })
               .ToList().ForEach(grp =>
               {
                   row[string.Format($"#Supplier#{grp.SupplierId}#Product#{grp.ProductId}#")] = grp.Quantity;
               });
            dt.Rows.Add(row);
            return total;
        }

        private void GenerateHeader(List<RunLevel> runLevels, DataTable dt)
        {
            dt.Columns.Add(new DataColumn("#"));
            dt.Columns.Add(new DataColumn("##"));
            runLevels.GroupBy(rn => new { rn.SupplierId, rn.SupplierInfo.Name }).Select(s => new { SupplierId = s.Key.SupplierId, SupplierName = s.Key.Name, RunList = s.ToList() })
                .ToList().ForEach(grp =>
                {
                    dt.Columns.Add(new DataColumn(string.Format($"#Supplier#{grp.SupplierId}#")));
                    grp.RunList.ForEach(rn =>
                    {
                        if (!dt.Columns.Contains(string.Format($"#Supplier#{grp.SupplierId}#Product#{rn.ProductId}#")))
                            dt.Columns.Add(new DataColumn(string.Format($"#Supplier#{grp.SupplierId}#Product#{rn.ProductId}#")));
                    });
                });
            dt.Columns.Add(new DataColumn("###"));
            DataRow row = dt.NewRow();
            row["#"] = "SL NO";
            row["##"] = "Store Name";
            runLevels.GroupBy(rn => new { rn.SupplierId, rn.SupplierInfo.Name }).Select(s => new { SupplierId = s.Key.SupplierId, SupplierName = s.Key.Name, RunList = s.ToList() })
                .ToList().ForEach(grp =>
            {
                row[string.Format($"#Supplier#{grp.SupplierId}#")] = grp.SupplierName;

                grp.RunList.ForEach(rn =>
                {
                    row[string.Format($"#Supplier#{grp.SupplierId}#Product#{rn.ProductId}#")] = rn.ProductsInfo.Name;
                });
            });
            dt.Rows.Add(row);
        }

        private async Task GenerateRunCycleAsync(long orderId, long createdBy)
        {
            try
            {
                int runNumber = 0;
                Order order = await orderRepository.FindAsync(orderId);
                List<OrderProducts> orderProductsList = (List<OrderProducts>)await orderProductsRepository.FindAllAsync(op => op.OrderId == orderId && op.TemplateId == order.OrderTemplateId);
                long driverId = 0;
                int counter = 0;
                List<RunLevel> runLevelList = new();
                orderProductsList.OrderBy(op => op.StoreId).ToList().ForEach(op =>
                 {
                     var storeGroup = storeGroupStoreRepo.Find(st => st.StoreId == op.StoreId);
                     if (storeGroup != null)
                     {
                         var storeDriverMapping = storeGroupDriverRepo.Find(sd => sd.ID == storeGroup.StoreGroupId);
                         if (storeDriverMapping != null)
                         {
                             if (driverId != storeDriverMapping.DriverId)
                             {
                                 driverId = storeDriverMapping.DriverId;
                                 runNumber = runLevelList.Exists(rn => rn.DriverId == driverId) ? runLevelList.FirstOrDefault(rn => rn.DriverId == driverId).RunNumber : runNumber + 1;
                             }

                             var runLevel = new RunLevel()
                             {
                                 CreatedBy = createdBy,
                                 ModifiedBy = createdBy,
                                 IsActive = true,
                                 CreatedDate = DateTime.Now,
                                 ModifiedDate = DateTime.Now,
                                 RunNumber = runNumber,
                                 OrderProductId = op.ID,
                                 DriverId = driverId
                             };
                             runLevelList.Add(runLevel);
                             repository.CreateAsync(runLevel);
                             counter++;
                         }
                     }
                 });
                if (counter > 0)
                {
                    order.IsRunGenarated = true;
                    await orderRepository.UpdateAsyn(order, orderId);
                }
                else
                {
                    throw new CustomExceptions("No drivers found");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void GenerateExceptionMessage(Result<T> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }
        private static void GenerateExceptionMessage(Result<List<GeneratedRuns>> result, Exception ex)
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
