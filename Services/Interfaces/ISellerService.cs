using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface ISellerService
    {
        Task<UserSeller> CreateSellerAsync(AspNetUserCustom user, UserSellerDTO seller);
    }
}
