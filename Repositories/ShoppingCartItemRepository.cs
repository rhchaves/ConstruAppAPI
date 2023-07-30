using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;

namespace ConstruAppAPI.Repository
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(ModelContext context) : base(context)
        {
        }

    }
}
