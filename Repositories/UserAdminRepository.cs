using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class UserAdminRepository : Repository<UserAdmin>, IUserAdminRepository
    {
        public UserAdminRepository(ModelContext context) : base(context)
        {
        }

    }
}
