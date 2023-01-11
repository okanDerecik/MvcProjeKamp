using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        IAuthService authservices = new AuthManager(new AdminManager(new EFAdminDAL()));

        //AdminManager adm = new AdminManager(new EFAdminDAL());
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDAL());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLoginDto adminDto)
        {


            ////Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminPassword == result);

            //if(adminuserinfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
            //    Session["AdminUserName"]=adminuserinfo.AdminUserName;
            //    return RedirectToAction("Index", "Gallery");
            //}
            //    ViewBag.ErrorMessage = "Kullanıcı Adı yada Şifre Hatalı";
            //    return View();

            if (authservices.AdminLogin(adminDto))
            {
                FormsAuthentication.SetAuthCookie(adminDto.AdminMail, false);
                Session["AdminMail"] = adminDto.AdminMail;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı yada Şifre Hatalı";
                return View();
            }
            //return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}