namespace ConstruAppAPI.Models
{
    public partial class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int? QtdProduct { get; set; }
        public int? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
