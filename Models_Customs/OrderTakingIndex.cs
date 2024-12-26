namespace TylorShop.Models_Customs
{
    public class OrderTakingIndex
    {

        
        public int? Oid { get; set; }
        public bool? IsActive { get; set; }

        public string? Name { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DelevaryDate { get; set; }

        public bool? IsReady { get; set; }

        public bool? IsDelevered { get; set; }

        public bool? IsCancelled { get; set; }

        public double? Amount { get; set; }

        public double? Discount { get; set; }
    }
}
