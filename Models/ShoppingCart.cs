namespace ConstruAppAPI.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ShoppingCartId { get; set; }
        public string UserClientId { get; set; } = null!;
        public string Payment { get; set; } = null!;
        public int? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual UserClient UserClient { get; set; } = null!;
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
