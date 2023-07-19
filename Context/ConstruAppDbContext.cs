using ConstruAppAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ConstruAppAPI.Context
{
    public class ConstruAppDbContext : ModelContext
    {
        public ConstruAppDbContext(DbContextOptions<ConstruAppDbContext> options)
        { }

    }
}
