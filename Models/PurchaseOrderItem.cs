namespace ConstruAppAPI.Models
{
    public partial class PurchaseOrderItem
    {
        public int PurchaseOrderItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual Product? Product { get; set; } = null!;
        public virtual PurchaseOrder? PurchaseOrder { get; set; } = null!;
    }
}
