using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repositories
{
    public interface IContactRepository

    {
        ContactModel Add(ContactModel contact);

        HashSet<ContactModel> GetAll();
    }
}
