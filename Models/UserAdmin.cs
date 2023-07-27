namespace ConstruAppAPI.Models
{
    public partial class UserAdmin
    {
        public string? UserAdminId { get; set; }
        public string? FullName { get; set; }
        public string? Cpf { get; set; }
        public int TypeAdmin { get; set; }
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
    }
}
