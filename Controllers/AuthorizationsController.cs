using ConstruAppAPI.DTOs;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConstruAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : ControllerBase
    {
        private readonly IAuthorizationCustomService _authorizationCustomService;

        public AuthorizationsController(IAuthorizationCustomService authorizationCustomService)
        {
            _authorizationCustomService = authorizationCustomService;
        }

        [HttpPost("add-admin")]
        public async Task<ActionResult> AddAdminAsync([FromBody] UserAdminDTO userAdmin)
        {
            var result = await _authorizationCustomService.AddAdminAsync(userAdmin);

            if (result == null) return BadRequest("Email já cadastrado!"); // verificar como tratar esse caso

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(result.Succeeded);
        }

        [HttpPost("add-client")]
        public async Task<ActionResult> AddClientAsync([FromBody] UserClientDTO userClient)
        {
            var result = await _authorizationCustomService.AddClientAsync(userClient);

            if (result == null) return BadRequest("Email já cadastrado!"); // verificar como tratar esse caso

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(result.Succeeded);
        }

        [HttpPost("add-seller")]
        public async Task<ActionResult> AddSellerAsync([FromBody] UserSellerDTO userSeller)
        {
            var result = await _authorizationCustomService.AddSellerAsync(userSeller);

            if (result == null) return BadRequest("Email já cadastrado!"); // verificar como tratar esse caso

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(result.Succeeded);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] AspNetUserCustomDTO userInfo)
        {
            var result = await _authorizationCustomService.LoginAsync(userInfo);

            if (result == null) return Unauthorized("Usuário ou Senha Inválidos!");
            
            return Ok(result);
        }

    }
}
