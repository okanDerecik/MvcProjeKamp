using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }

    }
}