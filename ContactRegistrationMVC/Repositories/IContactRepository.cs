using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repositories
{
    public interface IContactRepository

    {
        ContactModel Add(ContactModel contact);

        ContactModel Update(ContactModel contact);

        bool Delete(int id);

        ContactModel FindId(int id);

        List<ContactModel> GetAll();
    }
}
