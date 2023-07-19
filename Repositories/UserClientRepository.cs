using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConstruAppAPI.Repository
{
    public class UserClientRepository : Repository<UserClient>, IUserClientRepository
    {
        public UserClientRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
