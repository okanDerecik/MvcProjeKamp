using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister (string AdminUserName, string AdminMail, string AdminPassword, int AdminRoleId);
        bool AdminLogin (AdminLoginDto adminDto);
    }
}
