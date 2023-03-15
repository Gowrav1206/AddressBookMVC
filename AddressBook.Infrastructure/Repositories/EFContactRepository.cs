using AddressBook.Data;
using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Repositories
{
    public class EFContactRepository : IContactRepository
    {
        private ApplicationDbContext _db;

        public EFContactRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void AddContact(Contact newContact)
        {
            this._db.AddressBook.Add(newContact);

            this._db.SaveChanges();
        }

        public void EditContact(Contact updatedContact)
        {
            this._db.Update(updatedContact);
            this._db.SaveChanges();
        }

        public void DeleteContact(int contactId)
        {
            var contact = this.GetContact(contactId);
            this._db.AddressBook.Remove(contact);
            this._db.SaveChanges();
        }

        public Contact GetContact(int contactId)
        {
            return this._db.AddressBook.Find(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return this._db.AddressBook.ToList();
        }
    }
}
