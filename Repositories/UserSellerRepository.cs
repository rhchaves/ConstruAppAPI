using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConstruAppAPI.Repository
{
    public class UserSellerRepository : Repository<UserSeller>, IUserSellerRepository
    {
        public UserSellerRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
