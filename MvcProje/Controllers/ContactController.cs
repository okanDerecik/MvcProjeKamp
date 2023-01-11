using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDAL());
        MessageManager mm = new MessageManager(new EFMessageDAL());
        ContactValidator cv = new ContactValidator();
        Context cont = new Context();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["AdminMail"];

            var contacts = cm.GetList().Count();
            ViewBag.contacts = contacts;

            var sender = mm.GetListSendbox(p).Count();
            ViewBag.sender = sender;

            var receiver= cont.Messages.Count(x=>x.ReceiverMail == "admin2@gmail.com").ToString();
            ViewBag.receiver = receiver;

            var drafts = cont.Messages.Count(x=>x.IsDraft==true).ToString();
            ViewBag.drafts = drafts;

            var unreadmessage = mm.GetListUnRead().Count();
            ViewBag.unreadmessage = unreadmessage; 

            var spam = mm.GetListSpam(p).Count();
            ViewBag.spam = spam;

            var trash = mm.GetListTrash(p).Count();
            ViewBag.trash = trash;

            return PartialView();
        }

        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }
    }
}