using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class UserSellerRepository : Repository<UserSeller>, IUserSellerRepository
    {
        public UserSellerRepository(ModelContext context) : base(context)
        {
        }

    }
}
