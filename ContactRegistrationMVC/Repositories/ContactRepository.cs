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

        public HashSet<ContactModel> GetAll()
        {
            return _databaseContext.Contacts.ToHashSet();
        }

        public ContactModel Add(ContactModel contact)
        {
            //Adds contact to database
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();

            return contact;
        }

    }
}
