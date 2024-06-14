using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repositories
{
    public interface IUserRepository

    {
        UserModel Add(UserModel contact);

        UserModel Update(UserModel contact);

        bool Delete(int id);

        UserModel FindId(int id);

        List<UserModel> GetAll();
    }
}
