using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {

        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var totalheading = c.Headings.Count();
            ViewBag.Totalheading = totalheading;

            var totalcategory = c.Categories.Count();
            ViewBag.TotalCategory = totalcategory;

            var totalwriter = c.Writers.Count();
            ViewBag.Totalwriter = totalwriter;

            var truecategory = c.Categories.Where(x=>x.CategoryStatus == true).Count();
            ViewBag.truecategory = truecategory;

            return View();
        }
    }
}