using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Helper
{
    public interface IUserSession
    {
        void StartSession(UserModel user);
        void EndSession();
        UserModel FindSession();
    }
}
