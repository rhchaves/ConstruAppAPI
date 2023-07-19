namespace ConstruAppAPI.Models
{
    public partial class UserAdmin
    {
        public string UserAdminId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }
    }
}
