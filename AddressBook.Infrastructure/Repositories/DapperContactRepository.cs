using AddressBook.Data;
using AddressBook.Interfaces;
using AddressBook.Models;
using Dapper.Contrib.Extensions;

namespace AddressBook.Repositories
{
    public class DapperContactRepository : IContactRepository
    {
        private ContactsDbContext _db;

        public DapperContactRepository(ContactsDbContext db)
        {
            this._db = db;
        }

        public void AddContact(Contact newContact)
        {
            _db.connection.Insert(newContact);
        }

        public void EditContact(Contact updatedContact)
        {
            _db.connection.Update(updatedContact);
        }

        public void DeleteContact(int contactId)
        {
            Contact contact = this.GetContact(contactId);
            _db.connection.Delete(contact);
        }

        public Contact GetContact(int contactId)
        {
            Contact contact = _db.connection.Get<Contact>(contactId);
            return contact;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _db.connection.GetAll<Contact>();
        }
    }
}