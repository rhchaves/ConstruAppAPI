namespace ConstruAppAPI.Models
{
    public partial class UserSeller
    {
        public UserSeller()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string UserSellerId { get; set; }
        public string UserId { get; set; }
        public string FantasyName { get; set; }
        public string Cnpj { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public string ZipCode { get; set; }
        public string? Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
