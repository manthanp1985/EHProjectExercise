using MaintainContacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaintainContacts.Services
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactByID(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
