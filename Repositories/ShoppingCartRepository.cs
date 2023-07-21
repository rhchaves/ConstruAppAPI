using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ModelContext context) : base(context)
        {
        }

    }
}
