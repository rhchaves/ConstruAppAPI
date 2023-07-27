using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface IAdminService
    {
        Task<UserAdmin> CreateAdminAsync(AspNetUserCustom user, UserAdminDTO admin);
    }
}
