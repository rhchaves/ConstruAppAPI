namespace ConstruAppAPI.Models
{
    public partial class UserSeller
    {
        public UserSeller()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string UserSellerId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FantasyName { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string AddressNumber { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Complement { get; set; }
        public string District { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
