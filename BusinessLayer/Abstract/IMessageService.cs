using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListRead(string p);
        List<Message> GetListUnRead();
        List<Message> GetIsDraft(string p);
        List<Message> GetListTrash(string p);
        List<Message> GetListSpam(string p);
        void MessageAdd(Message message);
        Message GetByID(int id);

        List<Message> GetList();
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
