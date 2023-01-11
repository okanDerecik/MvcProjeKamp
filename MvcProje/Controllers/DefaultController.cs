using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        ContentManager cm = new ContentManager(new EFContentDAL()); 

        public ActionResult Headings()
        {
            var headlinglist = hm.GetList();
            return View(headlinglist);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}