using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ChartController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        WriterManager wm = new WriterManager(new EFWriterDAL());

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });

            return ct;
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult HeadingChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> categoryclass = new List<CategoryClass>();
            foreach (var item in hm.GetList().GroupBy(x => new { x.Category.CategoryName }))
            {
                categoryclass.Add(new CategoryClass()
                {
                    CategoryName = item.Key.CategoryName,
                    CategoryCount = hm.GetList().Where(x => x.Category.CategoryName == item.Key.CategoryName).Count()
                });
            }
            return categoryclass;
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterClass> WriterList()
        {
            List<WriterClass> writerclass = new List<WriterClass>();
            foreach (var item in wm.GetList().GroupBy(x => new { x.WriterTitle }))
            {
                writerclass.Add(new WriterClass()
                {
                    WriterTitle = item.Key.WriterTitle,
                    WriterCount = wm.GetList().Where(x => x.WriterTitle == item.Key.WriterTitle).Count()
                });
            }
            return writerclass;
        }
    }
}