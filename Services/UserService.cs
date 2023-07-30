using ConstruAppAPI.DTOs;
using ConstruAppAPI.Models;
using ConstruAppAPI.Services.Interfaces;

namespace ConstruAppAPI.Services
{
    public class UserService : IUserService
    {
        public AspNetUserCustom GenereteNewUserAdmin(UserAdminDTO userAdmin)
        {
            AspNetUserCustom newUser = new AspNetUserCustom
            {
                UserName = userAdmin.UserName,
                Email = userAdmin.Email,
                PasswordHash = userAdmin.Password,
                PhoneNumber = userAdmin.PhoneNumber,
                EmailConfirmed = true,
                Status = 1,
                UpdateStatus = DateTime.Now,
                CreateRegister = DateTime.Now,
                UpdateRegister = DateTime.Now,
            };

            return newUser;
        }

        public AspNetUserCustom GenereteNewUserClient(UserClientDTO userClient)
        {
            AspNetUserCustom newUser = new AspNetUserCustom
            {
                UserName = userClient.UserName,
                Email = userClient.Email,
                PasswordHash = userClient.Password,
                PhoneNumber = userClient.PhoneNumber,
                EmailConfirmed = true,
                Status = 1,
                UpdateStatus = DateTime.Now,
                CreateRegister = DateTime.Now,
                UpdateRegister = DateTime.Now,
            };

            return newUser;
        }

        public AspNetUserCustom GenereteNewUserSeller(UserSellerDTO userSeller)
        {
            AspNetUserCustom newUser = new AspNetUserCustom
            {
                UserName = userSeller.UserName,
                Email = userSeller.Email,
                PasswordHash = userSeller.Password,
                PhoneNumber = userSeller.PhoneNumber,
                EmailConfirmed = true,
                Status = 0,
                UpdateStatus = DateTime.Now,
                CreateRegister = DateTime.Now,
                UpdateRegister = DateTime.Now,
            };

            return newUser;
        }
    }
}
