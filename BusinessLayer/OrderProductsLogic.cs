using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;
using ModelLayer.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderProductsLogic<T> : BaseBusiness<T>, IOrderProductsLogic<T> where T : OrderProducts
    {

        private readonly IOrderProductsRepository<OrderProducts> repository;
        private readonly IOrderRepository<Order> orderRepository;
        private readonly IProductRepository<ProductInformation> productRepository;
        private readonly IOrderTemplateProductsRepository<OrderTemplateProducts> templateRepo;
        private readonly IProductSupplierUnitPriceRepository<ProductSupplierUnitPrice> productSupplierUnitPriceRepo;
        private readonly ICategoryStoreRepository<CategoryStore> categoryStoreRepository;
        private readonly ICategoryProductRepository<CategoryProduct> categoryProductRepository;
        private readonly ISupplierRepository<Supplier> supplierRepository;
        private readonly IExcemptionsRepository<Excemptions> excemptionRepository;
        public OrderProductsLogic() : base((IBaseRepository<T>)new OrderProductsRepository())
        {
            repository = new OrderProductsRepository();
            orderRepository = new OrderRepository();
            productSupplierUnitPriceRepo = new ProductSupplierUnitPriceRepository();
            categoryStoreRepository = new CategoryStoreRepository();
            categoryProductRepository = new CategoryProductRepository();
            templateRepo = new OrderTemplateProductsRepository();
            supplierRepository = new SupplierRepository();
            excemptionRepository = new ExcemptionsRepository();
            productRepository = new ProductRepository();
        }
        public async Task<Result<List<T>>> GetAllByOrderIdAsyn(long id)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.GetAllByOrderIdAsyn(id);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<bool> UpsertByOrderTemplateId(long orderId, long templateId)
        {
            return await repository.UpsertByOrderTemplateId(orderId, templateId);
        }
        public async Task<Result<T>> PostOrderProducts(List<OrderProducts> orderProductsList)
        {
            Result<T> result = new();
            try
            {
                orderProductsList.ForEach(p =>
                {
                    if (p.ID > 0)
                        repository.UpdateAsyn((OrderProducts)p, p.ID);
                    else
                        repository.CreateAsync((OrderProducts)p);
                });
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;

        }
        public async Task<Result<T>> AddProducts(AddProducts entity)
        {
            Result<T> result = new();
            try
            {
                AddOrderProducts(entity);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;

        }
        public async Task<Result<T>> ChangeOrderTemplate(long orderId, long templateId, long createdBy)
        {
            Result<T> result = new();
            try
            {
                result.Success = await ChangeOrderTemplateProducts(orderId, templateId, createdBy);
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;

        }
        public async Task<Result<T>> SaveProductQuantity(long id, double quantity, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await repository.SaveProductQuantity(id, quantity, createdBy);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> SaveSequenceNumber(long id, long supplierId, int sequenceNumber, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await repository.SaveSequenceNumber(id, supplierId, sequenceNumber, createdBy);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> SaveSalesDay(long id, long supplierId, int salesDay, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await repository.SaveSalesDay(id, supplierId, salesDay, createdBy);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<T>> EnableDisable(long id, long supplierId, bool enable, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await repository.EnableDisable(id, supplierId, enable, createdBy);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }
        public async Task<Result<List<List<string>>>> GenerateOrderProducts(long orderId, long supplierId, long templateId)
        {
            Result<List<List<string>>> result = new();
            try
            {
                DataTable dt = await GenerateDataTble(orderId, supplierId, templateId);
                result.Data = dt.ConvertDtToList();
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ResultMessages.Exception;
                result.Error = ex.Message;
                result.Exceptions = ex.StackTrace;
            }
            return result;
        }

        public async Task<Result<T>> SendMailToSupplier(long orderId, long supplierId, long templateId)
        {
            Result<T> result = new();
            try
            {
                await GenerateAndSendMail(orderId, supplierId);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        public async Task<Result<T>> SendMailToSuppliersByOrderId(long orderId, long createdBy)
        {
            Result<T> result = new();
            try
            {
                await GenerateAndSendMail(orderId, null);
                result.Success = true;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        private async Task GenerateAndSendMail(long orderId, long? supplierId)
        {
            Order order = await orderRepository.FindAsync(orderId);
            List<OrderProducts> orderProducts = (List<OrderProducts>)await repository.FindAllAsync(op => op.OrderId == orderId
            && op.TemplateId == order.OrderTemplateId && (supplierId == 0 || op.SupplierId == supplierId.Value));

            // taking supplier seperately since this is a generic method
            List<long> suppliers = orderProducts.GroupBy(op => op.SupplierId).Select(s => s.Key).ToList();

            var details = orderProducts.GroupBy(g => new { g.SupplierId, g.ProductId })
                .Select(op => new EmailProducts()
                {
                    SupplierId = op.Key.SupplierId,
                    ProductId = op.Key.ProductId,
                    ProductName = productRepository.Find(p => p.ID == op.Key.ProductId).Name,
                    Total = op.Sum(o => o.Quantity)
                }).ToList();

            suppliers.ForEach(async s =>
            {
                var supplier = await supplierRepository.FindAsync(s);
                string body = details.FindAll(p => p.SupplierId == s).GenerateHtml(supplier.Name);
                EmailUtility.SendMail(supplier.ContactInfo.Email, "Order Number :" + orderId + " Product request", body);
            });

        }

        //private async Task<bool> GenerateAndSendMail(long orderId, long supplierId, long templateId)
        //{
        //    DataTable dt = await GenerateDataTble(orderId, supplierId, templateId);
        //    Supplier supplier = await supplierRepository.FindAsync(supplierId);
        //    string body = dt.GenerateHtml();
        //    EmailUtility.SendMail(supplier.ContactInfo.Email, "Item Request", body);
        //    return true;
        //}

        private void AddOrderProducts(AddProducts entity)
        {
            Order order = orderRepository.Find(ord => ord.ID == entity.ID);
            var productSupplierList = productSupplierUnitPriceRepo.FindAll(ps => ps.SupplierId == entity.SupplierId)
                .Where(ps => ps.EffectiveFromDate <= DateTime.Now && ps.EffectiveTillDate >= DateTime.Now).Select(ps => ps.ProductId).ToList();
            entity.StoreIdList.ForEach(st =>
            {
                var categoryStore = categoryStoreRepository.FindAll(cs => cs.StoreId == st).FirstOrDefault();
                if (categoryStore != null)
                {
                    var productList = categoryProductRepository.FindAll(cp => cp.CategoryId == categoryStore.CategoryId)
                    .Where(cp => productSupplierList.Contains(cp.ProductId));

                    productList.ToList().ForEach(pl =>
                    {
                        var existingItem = repository.Find(f => f.OrderId == entity.ID && f.TemplateId == order.OrderTemplateId && f.ProductId == pl.ProductId && f.StoreId == st && f.SupplierId == entity.SupplierId);
                        if (existingItem == null)
                            base.curdRepository.CreateAsync((T)new OrderProducts()
                            {
                                CreatedBy = entity.CreatedBy,
                                OrderId = entity.ID,
                                StoreId = st,
                                TemplateId = order.OrderTemplateId,
                                ProductId = pl.ProductId,
                                SupplierId = entity.SupplierId,
                                CreatedDate = entity.CreatedDate,
                                ModifiedBy = entity.ModifiedBy,
                                ModifiedDate = entity.ModifiedDate,
                                IsActive = entity.IsActive
                            });
                    });
                }
            });
        }
        private async Task<bool> ChangeOrderTemplateProducts(long orderId, long templateId, long createdBy)
        {
            Order order = await orderRepository.FindAsync(orderId);
            Excemptions exemption = excemptionRepository.FindAll(ex => ex.OrderTemplateId == templateId && ex.FromDate <= order.OrderDay && ex.ToDate >= order.OrderDay).FirstOrDefault();
            double multiplier = 0;
            if (exemption != null && exemption.ID > 0)
            {
                multiplier = exemption.MultiplyOders;
            }
            templateRepo.FindAll(temp => temp.OrderTemplateId == templateId && temp.IsActive == true).ToList().ForEach(item =>
              {
                  var product = repository.Find(pr => pr.OrderId == orderId && pr.TemplateId == templateId &&
                    pr.ProductId == item.ProductId && pr.StoreId == item.StoreId && pr.SupplierId == item.SupplierId);

                  if (product == null)
                      repository.CreateAsync(new OrderProducts()
                      {
                          IsActive = true,
                          CreatedBy = createdBy,
                          ModifiedBy = createdBy,
                          CreatedDate = DateTime.Now,
                          ModifiedDate = DateTime.Now,
                          OrderId = orderId,
                          ProductId = item.ProductId,
                          Quantity = multiplier != 0 ? ((int)Math.Ceiling(item.Quantity + (item.Quantity * multiplier))) : item.Quantity,
                          SalesDay = item.SalesDay,
                          SequenceNumber = item.SequenceNumber,
                          StoreId = item.StoreId,
                          SupplierId = item.SupplierId,
                          TemplateId = templateId
                      });
              });
            return true;
        }

        private async Task<DataTable> GenerateDataTble(long orderId, long supplierId, long templateId)
        {
            DataTable resultDs = new();
            Dictionary<long, double> footerProductList = new();
            List<ProductSupplierUnitPrice> productSupplierList = (List<ProductSupplierUnitPrice>)await productSupplierUnitPriceRepo.FindAllBySupplierIdAsync(supplierId);
            if (productSupplierList.Count > 0)
            {
                List<long> productList = productSupplierList.OrderBy(o => o.ProductId).Select(s => s.ProductId).ToList();
                List<OrderProducts> templateProductList = (List<OrderProducts>)await repository.GetAllBySupplierIdandOrderIdAsync(orderId, supplierId, templateId);

                GenerateHeader(resultDs, productSupplierList, productList, footerProductList);

                if (templateProductList.Count > 0)
                    GenerateRows(resultDs, templateProductList, footerProductList);

                GenerateFooter(resultDs, footerProductList);
            }


            return resultDs;
        }

        private void GenerateFooter(DataTable resultDs, Dictionary<long, double> footerProductList)
        {
            DataRow row = resultDs.NewRow();
            row["#"] = string.Format($"label##{001}##Total##StoreName");
            footerProductList.ToList().ForEach(item =>
            {
                row[item.Key.ToString()] = string.Format($"label##{item.Key.ToString()}##{item.Value.ToString()}##Quantity");
            });
            resultDs.Rows.Add(row);
        }
        private static void GenerateRows(DataTable resultDs, List<OrderProducts> templateProductList, Dictionary<long, double> footerProductList)
        {
            DataRow row = resultDs.NewRow();
            long storeId = 0;
            templateProductList.OrderBy(o => o.StoreId).ToList().ForEach(tp =>
            {
                if (storeId != tp.StoreId)
                {
                    if (storeId != 0)
                        resultDs.Rows.Add(row);
                    row = resultDs.NewRow();
                    storeId = tp.StoreId;
                    row["#"] = string.Format($"label##{tp.ID}##{tp.StoreInfo.Name}##StoreName");
                    //row["##"] = string.Format($"text##{tp.ID}##{tp.SequenceNumber}##SequenceNumber");
                    // row["###"] = string.Format($"text##{tp.ID}##{tp.SalesDay}##SalesDay");
                    row["####"] = string.Format($"checkbox##{tp.ID}##{tp.IsActive}##IsActive");
                }
                row[tp.ProductId.ToString()] = string.Format($"text##{tp.ID}##{tp.Quantity}##Quantity");

                if (footerProductList.ContainsKey(tp.ProductId))
                {
                    var currentVal = Convert.ToDouble(footerProductList[tp.ProductId].ToString()) + Convert.ToDouble(tp.Quantity);
                    footerProductList[tp.ProductId] = currentVal;
                }
            });
            resultDs.Rows.Add(row);
        }
        private static void GenerateHeader(DataTable resultDs, List<ProductSupplierUnitPrice> productSupplierList, List<long> productList, Dictionary<long, double> footerProductList)
        {
            resultDs.Columns.Add(new DataColumn("#"));
            //resultDs.Columns.Add(new DataColumn("##"));
            productList.Distinct().ToList().ForEach(p =>
            {
                resultDs.Columns.Add(new DataColumn(p.ToString()));
            });
            //resultDs.Columns.Add(new DataColumn("###"));
            resultDs.Columns.Add(new DataColumn("####"));

            DataRow row = resultDs.NewRow();
            row["#"] = "Store Name";
            //row["##"] = "Sequence Number";
            // row["###"] = "Sales Day";
            row["####"] = "Deactivate";
            productSupplierList.ForEach(sp =>
            {
                row[sp.ProductId.ToString()] = sp.ProductInfo.Name;
                footerProductList[sp.ProductId] = 0;
            });

            resultDs.Rows.Add(row);
        }
        private static void GenerateExceptionMessage(Result<List<T>> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }
        private static void GenerateExceptionMessage(Result<T> result, Exception ex)
        {
            result.Success = false;
            result.Message = ResultMessages.Exception;
            result.Error = ex.Message;
            result.Exceptions = ex.StackTrace;
        }
    }
}
