namespace ConstruAppAPI.Models
{
    public partial class UserClient
    {
        public UserClient()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string? UserClientId { get; set; }
        public string? FullName { get; set; }
        public string? Cpf { get; set; }
        public int? TypeClient { get; set; }
        public string? Street { get; set; }
        public string? AddressNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
