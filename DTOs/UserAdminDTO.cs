namespace ConstruAppAPI.DTOs
{
    public partial class UserAdminDTO
    {
        public string UserAdminId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public bool? Status { get; set; }
    }
}
