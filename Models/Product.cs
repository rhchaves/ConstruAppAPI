namespace ConstruAppAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProductMark { get; set; } = null!;
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

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
