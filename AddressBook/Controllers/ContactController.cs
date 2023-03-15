using AddressBook.Interfaces;
using AddressBook.Models;
using AddressBook.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices _service;

        private readonly IMapper _mapper;

        public ContactController(IContactServices service , IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public ActionResult Index()
        {
            var contact = this._service.GetContacts().FirstOrDefault();

            if (contact != null)
            {
                return Redirect("/contact/displaycontactdetails/" + contact.ContactId);
            }

            return View();
        }

        public ActionResult DisplayContactDetails(int id)
        {

            Contact contact = this._service.GetContact(id);

            return View(contact);
        }

        public ActionResult AddContactForm()
        {
            return View("ContactForm");
        }

        public ActionResult EditContactForm(int id) 
        {
            Contact contact = this._service.GetContact(id);
            ContactView contactView = _mapper.Map<ContactView>(contact);
            return View("ContactForm", contactView);
        }

        [HttpPost]
        public ActionResult ContactForm(ContactView contactView)
        {
            ContactView contactViewModel;
            Contact contact = _mapper.Map<Contact>(contactView);
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    this._service.AddContact(contact);
                }
                else
                {
                    this._service.EditContact(contact);
                }
                return Redirect("/contact/displaycontactdetails/" + contact.ContactId);
            }
            else
            {
                contactViewModel = _mapper.Map<ContactView>(contact);
                return View(contactView);
            }
        }

        public ActionResult DeleteExistingContact(int id)
        {
            this._service.DeleteContact(id);

            return Redirect("/contact/index");
        }
    }
}
