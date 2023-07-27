namespace ConstruAppAPI.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            UserAdmins = new HashSet<UserAdmin>();
            UserClients = new HashSet<UserClient>();
            UserSellers = new HashSet<UserSeller>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? NormalizedUserName { get; set; }
        public string Email { get; set; } = null!;
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime? UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<UserAdmin> UserAdmins { get; set; }
        public virtual ICollection<UserClient> UserClients { get; set; }
        public virtual ICollection<UserSeller> UserSellers { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
