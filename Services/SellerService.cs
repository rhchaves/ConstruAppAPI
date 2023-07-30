using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ConstruAppAPI.Services
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public SellerService(IUnitOfWork context, UserManager<AspNetUserCustom> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserSeller> CreateSellerAsync(AspNetUserCustom user, UserSellerDTO seller)
        {
            try
            {
                UserSeller newClient = GenereteNewSeller(user, seller);

                _context.UserSellerRepository.AddItem(newClient);
                await _context.CommitAsync();

                IdentityResult result = await AttributeClaimsAsync(user, seller.TypeSeller);

                return newClient;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao criar o vendedor: " + error.Message);
            }
        }

        private static UserSeller GenereteNewSeller(AspNetUserCustom user, UserSellerDTO seller)
        {
            UserSeller newClient = new UserSeller
            {
                AspNetUserId = user.Id,
                UserSellerId = user.Id,
                FantasyName = seller.FantasyName,
                Cnpj = seller.Cnpj,
                TypeSeller = seller.TypeSeller,
                Street = seller.Street,
                AddressNumber = seller.AddressNumber,
                ZipCode = seller.ZipCode,
                Complement = seller.Complement,
                District = seller.District,
                City = seller.City,
                State = seller.State,
            };

            return newClient;
        }

        private async Task<IdentityResult> AttributeClaimsAsync(AspNetUserCustom user, int sellerType)
        {
            List<Claim> claims;

            if (sellerType == 1)
            {
                claims = new List<Claim>
                {
                    new Claim("simple_seller", "vendedor_simples"), // alterar tipo de vendedor
                    new Claim(ClaimTypes.Role, "seller_role")
                };
            }
            else if (sellerType == 2)
            {
                claims = new List<Claim>
                {
                    new Claim("simple_seller", "vendedor_simples"), // alterar tipo de vendedor
                    new Claim(ClaimTypes.Role, "seller_role")
                };
            }
            else
            {
                claims = new List<Claim>
                {
                    new Claim("simple_seller", "vendedor_simples"),
                    new Claim(ClaimTypes.Role, "seller_role")
                };
            }

            IdentityResult result = await _userManager.AddClaimsAsync(user, claims);

            return result;
        }
    }
}
