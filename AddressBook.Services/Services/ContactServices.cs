using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        public void AddContact(Contact newContact)
        {
            _contactRepository.AddContact(newContact);
        }

        public void EditContact(Contact updatedContact)
        {
            _contactRepository.EditContact(updatedContact);
        }

        public void DeleteContact(int contactId)
        {
            _contactRepository.DeleteContact(contactId);
        }

        public Contact GetContact(int contactId) 
        {
            return _contactRepository.GetContact(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contactRepository.GetContacts();
        }
    }
}