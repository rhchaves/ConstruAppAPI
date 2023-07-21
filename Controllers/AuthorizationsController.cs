using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConstruAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : ControllerBase
    {
        private readonly UserManager<AspUserCustom> _userManager;
        private readonly SignInManager<AspUserCustom> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthorizationsController(UserManager<AspUserCustom> userManager,
            SignInManager<AspUserCustom> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AuthorizeController ::  Acessado em  : "
               + DateTime.Now.ToLongDateString();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] UserDTO userInfo)
        {
            var user = new AspUserCustom
            {
                UserName = userInfo.UserName,
                Email = userInfo.Email,
                PasswordHash = userInfo.Password,
                PhoneNumber = userInfo.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userInfo.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.SignInAsync(user, false);
            return Ok(GenerateToken(userInfo));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] UserDTO userInfo)
        {
            // Verificar se o usuário existe
            var user = await _userManager.FindByNameAsync(userInfo.UserName);
            if (user == null)
            {
                return Unauthorized(); // Retorna 401 se o usuário não existe
            }

            // Verificar se as credenciais são válidas
            var result = await _signInManager.CheckPasswordSignInAsync(user, userInfo.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized(); // Retorna 401 se as credenciais forem inválidas
            }

            // Gerar o token JWT
            var token = GenerateToken(userInfo);

            return Ok(new { Token = token });
        }

        private UserToken GenerateToken(UserDTO userInfo)
        {
            //define declarações do usuário
            var claims = new[]
            {
                     new Claim(JwtRegisteredClaimNames.UniqueName, (userInfo.Email is null ? userInfo.UserName : userInfo.Email)),
                     new Claim("meuPet", "gordão"),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

            //gera uma chave com base em um algoritmo simetrico
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            //gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Tempo de expiracão do token.
            var expires = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expires));

            // classe que representa um token JWT e gera o token
            JwtSecurityToken token = new JwtSecurityToken(
              issuer: _configuration["TokenConfiguration:Issuer"],
              audience: _configuration["TokenConfiguration:Audience"],
              claims: claims,
              expires: expiration,
              signingCredentials: credentials);

            //retorna os dados com o token e informacoes
            return new UserToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT OK"
            };
        }
    }
}
