namespace ConstruAppAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ProductMark { get; set; }
        public decimal Price { get; set; }
        public string? ImageUri { get; set; }
        public int StockQtd { get; set; }
        public int SoldQtd { get; set; }
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
