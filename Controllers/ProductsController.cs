using ConstruAppAPI.Context;
using ConstruAppAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConstruAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ConstruAppDbContext _context;
        public ProductsController(ConstruAppDbContext context)
        {
            _context = context; 
        }
    }
}
