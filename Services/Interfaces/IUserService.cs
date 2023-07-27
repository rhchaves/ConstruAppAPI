using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        AspNetUserCustom GenereteNewUserAdmin(UserAdminDTO userAdmin);
        AspNetUserCustom GenereteNewUserClient(UserClientDTO userClient);
        AspNetUserCustom GenereteNewUserSeller(UserSellerDTO userSeller);

    }
}
