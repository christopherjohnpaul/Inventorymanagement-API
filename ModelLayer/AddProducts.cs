using ModelLayer.UIModels;
using System;
using System.Collections.Generic;

namespace ModelLayer
{
    public class AddProducts : BaseEntity
    {
        public List<long> StoreIdList { get; set; }
        public long SupplierId { get; set; }
        public static explicit operator AddProducts(AddProductsModel entity)
        {
            AddProducts model = new()
            {
                ID = entity.ID,
                StoreIdList = entity.StoreIdList,
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.CreatedBy,
                ModifiedDate = DateTime.Now,
                SupplierId = entity.SupplierId
            };
            return model;
        }
    }
}
