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

        public async Task<IdentityResult> AddAdminAsync(UserAdminDTO userAdmin)
        {
            AspNetUserCustom email = await _userManager.FindByEmailAsync(userAdmin.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail" });

            AspNetUserCustom newUser = _userService.GenereteNewUserAdmin(userAdmin);
            try
            {
                IdentityResult resultUser = await _userManager.CreateAsync(newUser, userAdmin.Password);
                UserAdmin resultAdmin = await _adminService.CreateAdminAsync(newUser, userAdmin);

                return IdentityResult.Success;
            }
            catch (Exception error)
            {
                await _userManager.DeleteAsync(newUser);

                return IdentityResult.Failed(new IdentityError { Description = error.Message });
            }
        }

        public async Task<IdentityResult> AddClientAsync(UserClientDTO userClient)
        {
            AspNetUserCustom email = await _userManager.FindByEmailAsync(userClient.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail" });

            AspNetUserCustom newUser = _userService.GenereteNewUserClient(userClient);
            try
            {
                IdentityResult resultUser = await _userManager.CreateAsync(newUser, userClient.Password);
                UserClient resultClient = await _clientService.CreateClientAsync(newUser, userClient);

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
            AspNetUserCustom email = await _userManager.FindByEmailAsync(userSeller.Email);

            if (email != null) return IdentityResult.Failed(new IdentityError { Description = "Erro de e-mail" });

            AspNetUserCustom newUser = _userService.GenereteNewUserSeller(userSeller);
            try
            {
                IdentityResult resultUser = await _userManager.CreateAsync(newUser, userSeller.Password);
                UserSeller resultSeller = await _sellerService.CreateSellerAsync(newUser, userSeller);

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
            try
            {
                AspNetUserCustom userLogin;

                // Verificar se as credenciais são válidas
                if (userInfo.UserName != null)
                    userLogin = await _userManager.FindByNameAsync(userInfo.UserName);
                else
                    userLogin = await _userManager.FindByEmailAsync(userInfo.Email);

                var result = await _signInManager.CheckPasswordSignInAsync(userLogin, userInfo.Password, lockoutOnFailure: false);

                if (userLogin == null || !result.Succeeded)
                {
                    return null;
                }

                // Gerar o token JWT
                UserToken token = GenerateToken(userInfo);

                return token;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        private UserToken GenerateToken(AspNetUserCustomDTO userInfo)
        {
            string strLoginUser;

            if (string.IsNullOrEmpty(userInfo.Email))
            {
                strLoginUser = userInfo.UserName.ToLower();
            }
            else
            {
                strLoginUser = userInfo.Email.ToLower();
            }

            //define declarações do usuário
            Claim[] claims = new[]
            {
                     new Claim(JwtRegisteredClaimNames.UniqueName, strLoginUser),
                     new Claim("meuPet", "gordão"),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

            //gera uma chave com base em um algoritmo simetrico
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            //gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Tempo de expiracão do token.
            string expires = _configuration["TokenConfiguration:ExpireHours"];
            DateTime expiration = DateTime.UtcNow.AddHours(double.Parse(expires));

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
