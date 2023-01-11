using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messagedal;

        public MessageManager(IMessageDAL messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListRead(string p)
        {
            return _messagedal.List(x => x.IsRead == true && x.ReceiverMail == p);
        }
        public List<Message> GetListUnRead()
        {
            return _messagedal.List(x => x.ReceiverMail == "admin2@gmail.com").Where(x => x.IsRead == false).ToList();
        }

        public List<Message> GetListInbox(string p)
        {
            return _messagedal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messagedal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }

        public List<Message> GetIsDraft(string p)
        {
            return _messagedal.List(x => x.IsDraft == true && x.SenderMail == p);
        }

        public List<Message> GetListTrash(string p)
        {
            return _messagedal.List(x => x.Trash == true);
        }

        public List<Message> GetListSpam(string p)
        {
            return _messagedal.List(x => x.IsSpam == true && x.ReceiverMail == p);
        }

        public List<Message> GetList()
        {
            return _messagedal.List(x => x.ReceiverMail == "admin2@gmail.com");
        }
    }
}
