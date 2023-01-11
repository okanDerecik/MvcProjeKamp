using BusinessLayer.Abstract;
using BusinessLayer.Utilities.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public void AdminRegister(string AdminUserName, string AdminMail, string AdminPassword, int AdminRoleId)
        {
            byte[] UserNameHash, PasswordHash, PasswordSalt;
            HashingHelper.AdminCreatePasswordHash(AdminMail, AdminPassword, out UserNameHash, out PasswordHash, out PasswordSalt);
            var admin = new Admin
            {
                AdminUserName = AdminUserName,
                AdminMail = UserNameHash,
                AdminPasswordHash = PasswordHash,
                AdminPasswordSalt = PasswordSalt,
                RoleId = AdminRoleId
            };
            _adminService.AdminAdd(admin);
        }

        public bool AdminLogin(AdminLoginDto adminDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var UserNameHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminDto.AdminUserName));
                var User = _adminService.GetList();
                foreach(var item in User)
                {
                    if (HashingHelper.AdminVerifyPasswordHash(adminDto.AdminUserName, adminDto.AdminPassword, item.AdminMail, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

       
    }
}
