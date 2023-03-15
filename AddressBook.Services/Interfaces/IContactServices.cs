using AddressBook.Models;

namespace AddressBook.Interfaces
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

         void EditContact(Contact updatedContact);

         void DeleteContact(int contactId);

         Contact GetContact(int contactId);

         IEnumerable<Contact> GetContacts();
    }
}
