using ConstruAppAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ConstruAppAPI.Context
{
    public class ConstruAppDbContext : IdentityDbContext<AspUserCustom>
    {
        public ConstruAppDbContext(DbContextOptions<ConstruAppDbContext> options) : base(options)
        { }

    }
}
