using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ScheduleController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ScheduleClass());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new ScheduleClass();
            var events = new List<ScheduleClass>();

            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach(var item in hm.GetList())
            {
                events.Add(new ScheduleClass()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });
            }

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
       
    }
}