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
    public class SkillController : Controller
    {
        // GET: Skill

        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
        public ActionResult SkillCard()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            sm.SkillAdd(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var values = sm.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            sm.SkillUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skillvalues = sm.GetByID(id);
            sm.SkillDelete(skillvalues);
            return RedirectToAction("Index");
        }

    }
}