namespace ConstruAppAPI.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
        }

        public int PurchaseOrderId { get; set; }
        public string UserClientId { get; set; } = null!;
        public string UserSellerId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual UserClient UserClient { get; set; } = null!;
        public virtual UserSeller UserSeller { get; set; } = null!;
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
