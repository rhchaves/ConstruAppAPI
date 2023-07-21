namespace ConstruAppAPI.DTOs
{
    public partial class UserSellerDTO
    {
        public UserSellerDTO()
        { }

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
       
    }
}
