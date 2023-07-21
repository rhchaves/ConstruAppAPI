using ConstruAppAPI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstruAppAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
