using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Location : BaseEntity
    {
        [MaxLength(100)]
        public string Suburb { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Latitude { get; set; }
        [MaxLength(100)]
        public string Longitude { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(100)]
        public string PostalCode { get; set; }

        public static explicit operator Location(LocationModel entity)
        {
            Location model = new();
            model.ID = entity.ID;
            model.Suburb = entity.Suburb;
            model.State = entity.State;
            model.Latitude = entity.Latitude;
            model.Longitude = entity.Longitude;
            model.AddressLine1 = entity.AddressLine1;
            model.AddressLine2 = entity.AddressLine2;
            model.PostalCode = entity.PostalCode;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;

            return model;
        }
    }
}
