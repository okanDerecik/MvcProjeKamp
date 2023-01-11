using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {

        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator messagevalidator = new MessageValidator();

        
        public ActionResult Inbox()
        {
            
            var messagelist = mm.GetList();
            return View(messagelist);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["SenderMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            string sender = (string)Session["AdminMail"];
            ValidationResult results = new ValidationResult();

            if (button == "draft")
            {
                results = messagevalidator.Validate(p);
                if (results.IsValid)
                {
                    p.SenderMail = sender;
                    p.IsDraft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());                   
                    mm.MessageAdd(p);
                    return RedirectToAction("DraftMessage");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                results = messagevalidator.Validate(p);
                if (results.IsValid)
                {
                    p.SenderMail = sender;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                   // p.IsDraft = false;
                    mm.MessageAdd(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
                return View();
        }

        public ActionResult DraftMessage(string p)
        {
            var Sendbox = mm.GetListSendbox(p);
            var Draft = Sendbox.FindAll(x => x.IsDraft == true);
            return View(Draft);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var DraftValues = mm.GetByID(id);
            return View(DraftValues);
        }

        public ActionResult IsRead(int id)
        {
            var readvalue = mm.GetByID(id);
            if(readvalue.IsRead == false)
            {
                readvalue.IsRead = true;
            }
            mm.MessageUpdate(readvalue);
            return RedirectToAction("ReadMessage");
        }

        //public ActionResult ReadMessage(int id)
        //{
        //    var readmessage = mm.GetList().Where(x => x.IsRead == true).ToList();
        //    return View(readmessage);
        //}

        public ActionResult UnReadMessage()
        {
            var unreadmessage = mm.GetListUnRead();
            return View(unreadmessage);
        }

    }
}