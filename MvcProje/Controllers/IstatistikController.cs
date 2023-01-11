using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class IstatistikController : Controller
    {
        Context con = new Context();
        public ActionResult Index()
        {
            var soru1 = con.Categories.Count().ToString();
            ViewBag.totalcategory = soru1;

            var soru2 = con.Headings.Where(x => x.CategoryID == 12).Count().ToString();
            ViewBag.totalheadingwithsoftware = soru2;

            var soru3 = con.Writers.Where(x => x.WriterName.Contains("a") || x.WriterSurname.Contains("a")).Count().ToString();
            ViewBag.containinglettera = soru3;

            var value = con.Headings.GroupBy(x=>x.CategoryID).Where(x=>x.Count()>1).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault();
            var soru4 = con.Categories.Where(x => x.CategoryID == value).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.icerik = soru4;

            var soru5true = con.Categories.Where(x => x.CategoryStatus == true).Count();
            var soru5false = con.Categories.Where(x => x.CategoryStatus == false).Count();
            ViewBag.difference = soru5true - soru5false;

            return View();
        }
    }
}