namespace ConstruAppAPI.DTOs
{
    public partial class UserClientDTO
    {
        public UserClientDTO()
        { }

        public string UserClientId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public string ZipCode { get; set; }
        public string? Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool? Status { get; set; }
    }
}
