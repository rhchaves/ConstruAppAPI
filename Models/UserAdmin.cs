namespace ConstruAppAPI.Models
{
    public partial class UserAdmin
    {
        public string UserAdminId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public int TypeAdmin { get; set; }
        public string AspNetUserId { get; set; } = null!;

        public virtual AspNetUser AspNetUser { get; set; } = null!;
    }
}
