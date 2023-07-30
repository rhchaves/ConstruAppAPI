namespace ConstruAppAPI.Models
{
    public partial class UserClient
    {
        public UserClient()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string UserClientId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public int? TypeClient { get; set; }
        public string Street { get; set; } = null!;
        public string AddressNumber { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Complement { get; set; }
        public string District { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
