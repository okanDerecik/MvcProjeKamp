using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EFAboutDAL());

        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteAbout(int id)
        {
            var AboutValue = abm.GetByID(id);
            if(AboutValue.AboutStatus == true)
            {
                AboutValue.AboutStatus = false;
                abm.AboutDelete(AboutValue);
            }
            else
            {
                AboutValue.AboutStatus = true;
                abm.AboutDelete(AboutValue);
            }

            return RedirectToAction("Index");
        }
    }
}