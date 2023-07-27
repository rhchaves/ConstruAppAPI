using ConstruAppAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConstruAppAPI.Services.Interfaces
{
    public interface IAuthorizationCustomService
    {
        
        Task<IdentityResult> AddAdminAsync([FromBody] UserAdminDTO userAdmin);
        Task<IdentityResult> AddClientAsync([FromBody] UserClientDTO userClient);
        Task<IdentityResult> AddSellerAsync([FromBody] UserSellerDTO userSeller);
        Task<UserToken> LoginAsync([FromBody] AspNetUserCustomDTO userInfo);
    }
}
