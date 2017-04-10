using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintainContacts.Entities;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Globalization;

namespace MaintainContacts.Services
{
    public class ContactRepository : CommonServices, IContactRepository
    {
        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public void Add(Contact contact)
        {
            contact.LastModifiedDate = DateTime.Now;
            contact.CreatedDate = DateTime.Now;
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(int id)
        {
            db.Contacts.Remove(db.Contacts.Where(c => c.ContactID == id).SingleOrDefault(c => c.ContactID == id));
            db.SaveChanges();
        }

        /// <summary>
        /// Get Contact using ID value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetContactByID(int id)
        {
            return db.Contacts.SingleOrDefault(c => c.ContactID == id);
        }

        /// <summary>
        /// Get all Contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetAllContacts()
        {
            return db.Contacts.ToList();
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public void Update(Contact contact)
        {
            Contact objContact = db.Contacts.SingleOrDefault(c => c.ContactID == contact.ContactID);
            objContact.FirstName = contact.FirstName;
            objContact.LastName = contact.LastName;
            objContact.Email = contact.Email;
            objContact.PhoneNumber = contact.PhoneNumber;
            objContact.StatusID = contact.StatusID;
            objContact.LastModifiedDate = DateTime.Now;

            db.Entry(objContact).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
