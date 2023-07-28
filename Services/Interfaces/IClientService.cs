using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface IClientService
    {
        Task<UserClient> CreateClientAsync(AspNetUserCustom user, UserClientDTO client);
    }
}
