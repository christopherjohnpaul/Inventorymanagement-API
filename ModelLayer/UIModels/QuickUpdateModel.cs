using System.ComponentModel.DataAnnotations;

namespace ModelLayer.UIModels
{
    public class QuickUpdateModel
    {
        public long ID { get; set; }
        public long RefId { get; set; }
        public long SecondRefId { get; set; }
        public double Quantity { get; set; }
        public int SalesDay { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public int SequenceNumber { get; set; }
    }
}
