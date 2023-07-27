using Microsoft.AspNetCore.Identity;

namespace ConstruAppAPI.Models
{
    public partial class AspNetUserCustom : IdentityUser
    {
        public AspNetUserCustom()
        {
        }
        
        public int? Status { get; set; }
        public DateTime? UpdateStatus { get; set; }
        public DateTime? CreateRegister { get; set; }
        public DateTime? UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

    }
}
