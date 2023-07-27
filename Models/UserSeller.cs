namespace ConstruAppAPI.Models
{
    public partial class UserSeller
    {
        public UserSeller()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string? UserSellerId { get; set; }
        public string? FantasyName { get; set; }
        public string? Cnpj { get; set; }
        public int? TypeSeller { get; set; }
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
    }
}
