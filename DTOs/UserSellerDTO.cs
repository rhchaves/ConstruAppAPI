namespace ConstruAppAPI.DTOs
{
    public partial class UserSellerDTO
    {
        public UserSellerDTO()
        { }

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
       
    }
}
