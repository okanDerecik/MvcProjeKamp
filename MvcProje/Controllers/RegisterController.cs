using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]  
    public class RegisterController : Controller
    {
        // GET: Register

        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDAL()));

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLoginDto adminLoginDto)
        {
            authService.AdminRegister(adminLoginDto.AdminUserName, adminLoginDto.AdminMail, adminLoginDto.AdminPassword, adminLoginDto.AdminRoleId);
            return RedirectToAction("Index","AdminCategory");
        }
    }
}