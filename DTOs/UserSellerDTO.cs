namespace ConstruAppAPI.DTOs
{
    public partial class UserSellerDTO : AspNetUserCustomDTO
    {
        public string? UserSellerId { get; set; }
        public string FantasyName { get; set; } = null!;
        public string Cnpj { get; set; } = null!; 
        public int TypeSeller { get; set; }
        public string Street { get; set; } = null!;
        public string AddressNumber { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Complement { get; set; }
        public string District { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;

    }
}
