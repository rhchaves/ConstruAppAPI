using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ConstruAppAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public AdminService(IUnitOfWork context, UserManager<AspNetUserCustom> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserAdmin> CreateAdminAsync(AspNetUserCustom user, UserAdminDTO admin)
        {
            try
            {
                UserAdmin newAdmin = GenereteNewAdmin(user, admin);

                _context.UserAdminRepository.AddItem(newAdmin);
                await _context.CommitAsync();

                IdentityResult result = await AttributeClaimsAsync(user, admin.TypeAdmin);

                return newAdmin;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao criar o admin: " + error.Message);
            }
        }

        private static UserAdmin GenereteNewAdmin(AspNetUserCustom user, UserAdminDTO admin)
        {
            UserAdmin newAdmin = new UserAdmin
            {
                AspNetUserId = user.Id,
                UserAdminId = user.Id,
                FullName = admin.FullName,
                Cpf = admin.Cpf,
                TypeAdmin = admin.TypeAdmin,
            };
            return newAdmin;
        }

        private async Task<IdentityResult> AttributeClaimsAsync(AspNetUserCustom user, int adminType)
        {
            List<Claim> claims;


            if (adminType == 1)
            {
                claims = new List<Claim>
                {
                    new Claim("general_admin", "administrador_geral"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };
            }
            else if (adminType == 2)
            {
                claims = new List<Claim>
                {
                    new Claim("product_admin", "administrador_produtos"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };
            }
            else if (adminType == 3)
            {
                claims = new List<Claim>
                {
                    new Claim("seller_admin", "administrador_vendedores"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };
            }
            else if (adminType == 4)
            {
                claims = new List<Claim>
                {
                    new Claim("client_admin", "administrador_clientes"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };
            }
            else if (adminType == 5)
            {
                claims = new List<Claim>
                {
                    new Claim("master_admin", "administrador_principal"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };

            }
            else
            {
                claims = new List<Claim>
                {
                    new Claim("simple_admin", "administrador_simples"),
                    new Claim(ClaimTypes.Role, "admin_role")
                };
            }

            IdentityResult result = await _userManager.AddClaimsAsync(user, claims);

            return result;
        }
    }
}
