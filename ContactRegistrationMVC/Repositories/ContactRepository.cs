using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ContactRepository(DatabaseContext dbc)
        {
            _databaseContext = dbc;
        }

        public ContactModel Add(ContactModel contact)
        {
            //Adds contact to database
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();

            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactInDB = FindId(contact.Id);

            if (contactInDB == null) throw new ArgumentException("There was an error updating this contact: This contact does not exist.");

            contactInDB.Name = contact.Name;
            contactInDB.Email = contact.Email;
            contactInDB.PhoneNumber = contact.PhoneNumber;

            _databaseContext.Contacts.Update(contactInDB);
            _databaseContext.SaveChanges();

            return contactInDB;
        }

        public bool Delete(int id)
        {
            ContactModel contactInDB = FindId(id);

            if (contactInDB == null) throw new ArgumentException("There was an error updating this contact: This contact does not exist.");

            _databaseContext.Contacts.Remove(contactInDB);
            _databaseContext.SaveChanges();

            return true;
        }

        public HashSet<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToHashSet();
        }

        public ContactModel FindId(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

    }
}
