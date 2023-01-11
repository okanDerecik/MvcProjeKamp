using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EFAdminDAL());
        IAuthService authService = new AuthManager(new AdminManager(new EFAdminDAL()));       
        RoleManager rm = new RoleManager(new EFRoleDAL());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> AdminRole = (from ar in rm.GetRoles()
                                              select new SelectListItem
                                              {
                                                  Text = ar.RoleName,
                                                  Value = ar.RoleId.ToString()
                                              }).ToList();
            ViewBag.RoleValue = AdminRole;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminLoginDto loginDto)
        {
            authService.AdminRegister(loginDto.AdminUserName, loginDto.AdminMail, loginDto.AdminPassword, loginDto.AdminRoleId);
            return RedirectToAction("Index");
            //adm.AdminAdd(p);
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adm.GetByID(id);
            adm.AdminUpdate(adminvalue);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = adm.GetByID(id);
            if (adminValue.AdminStatus == true)
            {
                adminValue.AdminStatus = false;
            }
            else
            {
                adminValue.AdminStatus = true;
            }
            adm.AdminUpdate(adminValue);
            return RedirectToAction("Index");
        }

    }
}