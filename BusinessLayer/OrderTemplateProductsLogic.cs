using DataLayer.Repositories;
using InterfaceLayer.Base;
using InterfaceLayer.Business;
using InterfaceLayer.Repository;
using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Data;
using System.Collections;
using ModelLayer.Utility;

namespace BusinessLayer
{
    public class OrderTemplateProductsLogic<T> : BaseBusiness<T>, IOrderTemplateProductsLogic<T> where T : OrderTemplateProducts
    {

        private readonly IOrderTemplateProductsRepository<OrderTemplateProducts> repository;
        private readonly IProductSupplierUnitPriceRepository<ProductSupplierUnitPrice> productSupplierUnitPriceRepo;
        private readonly ICategoryStoreRepository<CategoryStore> categoryStoreRepository;
        private readonly ICategoryProductRepository<CategoryProduct> categoryProductRepository;
        public OrderTemplateProductsLogic() : base((IBaseRepository<T>)new OrderTemplateProductsRepository())
        {
            repository = new OrderTemplateProductsRepository();
            productSupplierUnitPriceRepo = new ProductSupplierUnitPriceRepository();
            categoryStoreRepository = new CategoryStoreRepository();
            categoryProductRepository = new CategoryProductRepository();
        }
        public async Task<Result<List<T>>> GetAllByTemplateIdAsyn(long id)
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = (List<T>)await repository.GetAllByTemplateIdAsync(id);
                result.Success = result.Data != null;
                result.Message = ResultMessages.Success;
            }
            catch (Exception ex)
            {
                GenerateExceptionMessage(result, ex);
            }
            return result;
        }

        public async Task<Result<T>> PostTemplateProducts(List<OrderTemplateProducts> orderTemplateProducts)
        {
            Result<T> result = new();
            try
            {
                orderTemplateProducts.ForEach(p =>
                {
                    if (p.ID > 0)
                        repository.UpdateAsyn((OrderTemplateProducts)p, p.ID);
                    else
                        repository.CreateAsync((OrderTemplateProducts)p);
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
                AddTemplateProducts(entity);
                result.Success = true;
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

        private void AddTemplateProducts(AddProducts entity)
        {
            var productSupplierList = productSupplierUnitPriceRepo.FindAll(ps => ps.SupplierId == entity.SupplierId)
              .Where(ps => ps.EffectiveFromDate <= DateTime.Now && ps.EffectiveTillDate >= DateTime.Now).Select(ps => ps.ProductId).ToList();
            entity.StoreIdList.ForEach(st =>
           {
               var categoryStore = categoryStoreRepository.FindAll(cs => cs.StoreId == st).FirstOrDefault();
               if (categoryStore != null)
               {
                   var productList = categoryProductRepository.FindAll(cp => cp.CategoryId == categoryStore.CategoryId).Where(cp => productSupplierList.Contains(cp.ProductId));

                   productList.ToList().ForEach(pl =>
                   {
                       var existingItem = repository.Find(f => f.OrderTemplateId == entity.ID && f.ProductId == pl.ProductId && f.StoreId == st && f.SupplierId == entity.SupplierId);
                       if (existingItem == null)
                           base.curdRepository.CreateAsync((T)new OrderTemplateProducts()
                           {
                               CreatedBy = entity.CreatedBy,
                               OrderTemplateId = entity.ID,
                               StoreId = st,
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

        public async Task<Result<List<List<string>>>> GenerateOrderTemplateProducts(long orderTemplateId, long supplierId)
        {
            Result<List<List<string>>> result = new();
            try
            {
                DataTable dt = await GenerateDataTble(orderTemplateId, supplierId);
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

        private async Task<DataTable> GenerateDataTble(long orderTemplateId, long supplierId)
        {
            DataTable resultDs = new();
            Dictionary<long, double> footerProductList = new();
            List<ProductSupplierUnitPrice> productSupplierList = (List<ProductSupplierUnitPrice>)await productSupplierUnitPriceRepo.FindAllBySupplierIdAsync(supplierId);
            if (productSupplierList.Count > 0)
            {
                List<long> productList = productSupplierList.OrderBy(o => o.ProductId).Select(s => s.ProductId).ToList();
                List<OrderTemplateProducts> templateProductList = (List<OrderTemplateProducts>)await repository.GetAllBySupplierIdAndTemplateIdAsync(orderTemplateId, supplierId);

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

        private static void GenerateRows(DataTable resultDs, List<OrderTemplateProducts> templateProductList, Dictionary<long, double> footerProductList)
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
                    //row["###"] = string.Format($"text##{tp.ID}##{tp.SalesDay}##SalesDay");
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
            //row["###"] = "Sales Day";
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
