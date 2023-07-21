namespace ConstruAppAPI.Models
{
    public partial class UserAdmin
    {
        public string UserAdminId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }
    }
}
