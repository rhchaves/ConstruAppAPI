using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConstruAppAPI.Services
{
    public class AuthorizationCustomService : IAuthorizationCustomService
    {
        private readonly UserManager<AspNetUserCustom> _userManager;
        private readonly SignInManager<AspNetUserCustom> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly ISellerService _sellerService;
        public AuthorizationCustomService(UserManager<AspNetUserCustom> userManager, SignInManager<AspNetUserCustom> signInManager, IConfiguration configuration, 
            IAdminService adminService, IUserService userService, IClientService clientService, ISellerService sellerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _adminService = adminService;
            _userService = userService;
            _clientService = clientService;
            _sellerService = sellerService;
        }

        public async Task<IdentityResult> AddAdminAsync([FromBody] UserAdminDTO userAdmin)
        {
            var email = await _userManager.FindByEmailAsync(userAdmin.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail"});

            var newUser = _userService.GenereteNewUserAdmin(userAdmin);
            try
            {
                var resultUser = await _userManager.CreateAsync(newUser, userAdmin.Password);
                var resultAdmin = await _adminService.CreateAdminAsync(newUser, userAdmin);
                
                return IdentityResult.Success;
            }
            catch (Exception error)
            {
                await _userManager.DeleteAsync(newUser);

                return IdentityResult.Failed(new IdentityError { Description = error.Message });
            }
        }

        public async Task<IdentityResult> AddClientAsync([FromBody] UserClientDTO userClient)
        {
            var email = await _userManager.FindByEmailAsync(userClient.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail" });

            var newUser = _userService.GenereteNewUserClient(userClient);
            try
            {
                var resultUser = await _userManager.CreateAsync(newUser, userClient.Password);
                var resultClient = await _clientService.CreateClientAsync(newUser, userClient);

                return IdentityResult.Success;
            }
            catch (Exception error)
            {
                await _userManager.DeleteAsync(newUser);

                return IdentityResult.Failed(new IdentityError { Description = error.Message });
            }
        }

        public async Task<IdentityResult> AddSellerAsync([FromBody] UserSellerDTO userSeller)
        {
            var email = await _userManager.FindByEmailAsync(userSeller.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail" });

            var newUser = _userService.GenereteNewUserSeller(userSeller);
            try
            {
                var resultUser = await _userManager.CreateAsync(newUser, userSeller.Password);
                var resultSeller = await _sellerService.CreateSellerAsync(newUser, userSeller);

                return IdentityResult.Success;
            }
            catch (Exception error)
            {
                await _userManager.DeleteAsync(newUser);

                return IdentityResult.Failed(new IdentityError { Description = error.Message });
            }
        }

        public async Task<UserToken> LoginAsync([FromBody] AspNetUserCustomDTO userInfo)
        {
            AspNetUserCustom userLogin;

            if (userInfo.UserName != null)
                userLogin = await _userManager.FindByNameAsync(userInfo.UserName);
            else
                userLogin = await _userManager.FindByEmailAsync(userInfo.Email);

            // Verificar se as credenciais são válidas
            //var user = await _userManager.FindByNameAsync(userInfo.UserName);
            //var email = await _userManager.FindByEmailAsync(userInfo.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(userLogin, userInfo.Password, lockoutOnFailure: false);
            
            if (userLogin == null || !result.Succeeded)
            {
                return null;
            }

            // Gerar o token JWT
            var token = GenerateToken(userInfo);

            return token;
        }

        private UserToken GenerateToken(AspNetUserCustomDTO userInfo)
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
