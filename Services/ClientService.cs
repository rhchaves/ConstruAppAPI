using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Repository.Interfaces;
using ConstruAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ConstruAppAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public ClientService(IUnitOfWork context, UserManager<AspNetUserCustom> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserClient> CreateClientAsync(AspNetUserCustom user, UserClientDTO client)
        {
            try
            {
                UserClient newClient = GenereteNewClient(user, client);

                _context.UserClientRepository.AddItem(newClient);
                await _context.CommitAsync();

                IdentityResult result = await AttributeClaimsAsync(user, client.TypeClient);

                return newClient;
            }
            catch (Exception error)
            {
                throw new Exception("Ocorreu um erro ao criar o cliente: " + error.Message);
            }
        }

        private static UserClient GenereteNewClient(AspNetUserCustom user, UserClientDTO client)
        {
            UserClient newClient = new UserClient
            {
                AspNetUserId = user.Id,
                UserClientId = user.Id,
                FullName = client.FullName,
                Cpf = client.Cpf,
                TypeClient = client.TypeClient,
                Street = client.Street,
                AddressNumber = client.AddressNumber,
                ZipCode = client.ZipCode,
                Complement = client.Complement,
                District = client.District,
                City = client.City,
                State = client.State,
            };

            return newClient;
        }

        private async Task<IdentityResult> AttributeClaimsAsync(AspNetUserCustom user, int clientType)
        {
            List<Claim> claims;

            if (clientType == 1)
            {
                claims = new List<Claim>
                {
                    new Claim("simple_client", "cliente_simples"), // alterar tipo de cliente
                    new Claim(ClaimTypes.Role, "client_role")
                };
            }
            else if (clientType == 2)
            {
                claims = new List<Claim>
                {
                    new Claim("simple_client", "cliente_simples"), // alterar tipo de cliente
                    new Claim(ClaimTypes.Role, "client_role")
                };
            }
            else
            {
                claims = new List<Claim>
                {
                    new Claim("simple_client", "cliente_simples"),
                    new Claim(ClaimTypes.Role, "client_role")
                };
            }

            IdentityResult result = await _userManager.AddClaimsAsync(user, claims);

            return result;
        }
    }
}
