using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
