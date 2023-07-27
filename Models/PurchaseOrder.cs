namespace ConstruAppAPI.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
        }

        public int PurchaseOrderId { get; set; }
        public string UserClientId { get; set; }
        public string UserSellerId { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual UserClient UserClient { get; set; }
        public virtual UserSeller UserSeller { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
