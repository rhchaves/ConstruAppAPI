using ConstruAppAPI.Context;
using ConstruAppAPI.Models;
using ConstruAppAPI.Pagination;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConstruAppAPI.Repository
{
    public class UserAdminRepository : Repository<UserAdmin>, IUserAdminRepository
    {
        public UserAdminRepository(ConstruAppDbContext context) : base(context)
        {
        }

    }
}
