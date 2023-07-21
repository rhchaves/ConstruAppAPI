using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class UserClientRepository : Repository<UserClient>, IUserClientRepository
    {
        public UserClientRepository(ModelContext context) : base(context)
        {
        }

    }
}
