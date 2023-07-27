namespace ConstruAppAPI.DTOs
{
    public partial class UserAdminDTO : AspNetUserCustomDTO
    {
        public string? UserAdminId { get; set; }
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public int TypeAdmin { get; set; }
    }
}
