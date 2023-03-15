using AddressBook.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class ContactListViewComponent : ViewComponent
    {
        private readonly IContactServices _contactServices;

        public ContactListViewComponent(IContactServices contactServices)
        {
            this._contactServices = contactServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["ContactsList"] = _contactServices.GetContacts();
            return await Task.FromResult((IViewComponentResult)View("ContactList"));
        }
    }
}
