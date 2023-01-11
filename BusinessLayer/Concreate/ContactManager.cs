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
    public class ContactManager : IContactService
    {
        IContactDAL _Contactdal;

        public ContactManager(IContactDAL contactdal)
        {
            _Contactdal = contactdal;
        }

        public void ContactAdd(Contact contact)
        {
           _Contactdal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _Contactdal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _Contactdal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _Contactdal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _Contactdal.List();
        }
    }
}
