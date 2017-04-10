using MaintainContacts.Entities;
using MaintainContacts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintainContacts.Main.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository _icontactrepository;
        private IStatusRepository _iStatusRepository;
        private ILoggerRepository _iLoggerRepository;

        public ContactController(IContactRepository icontactrepository, IStatusRepository iStatusRepository, ILoggerRepository iLoggerRepository)
        {
            _icontactrepository = icontactrepository;
            _iStatusRepository = iStatusRepository;
            _iLoggerRepository = iLoggerRepository;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_icontactrepository.GetAllContacts());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View(_icontactrepository.GetContactByID(id));
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.Statues = _iStatusRepository.GetAllStatusesWithSelectedByID();
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Contact contact)
        {
            ViewBag.Statues = _iStatusRepository.GetAllStatusesWithSelectedByID(contact.ContactID);
            if(ModelState.IsValid)
            {
                _icontactrepository.Add(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Statues = _iStatusRepository.GetAllStatusesWithSelectedByID(id);
            return View(_icontactrepository.GetContactByID(id));
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind] Contact contact)
        {
            ViewBag.Statues = _iStatusRepository.GetAllStatusesWithSelectedByID(contact.ContactID);
            if (ModelState.IsValid)
            {
                _icontactrepository.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            _icontactrepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
