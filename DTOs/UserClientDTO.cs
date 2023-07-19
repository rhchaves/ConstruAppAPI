namespace ConstruAppAPI.DTOs
{
    public partial class UserClientDTO
    {
        public UserClientDTO()
        { }

        public string UserClientId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string AddressNumber { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Complement { get; set; }
        public string District { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public bool? Status { get; set; }
    }
}
