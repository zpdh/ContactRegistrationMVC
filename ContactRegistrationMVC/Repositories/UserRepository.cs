using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext dbc)
        {
            _databaseContext = dbc;
        }

        public UserModel Add(UserModel user)
        {
            //Adds user to database
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

            return user;
        }

        public UserModel Update(UserModel user)
        {
            UserModel userInDB = FindId(user.Id);

            if (userInDB == null) throw new ArgumentException("There was an error updating this user: This contact does not exist.");

            userInDB.Name = user.Name;
            userInDB.Login = user.Login;
            userInDB.Password = user.Password;
            userInDB.Email = user.Email;
            userInDB.UpdateDate = DateTime.Now;

            _databaseContext.Users.Update(userInDB);
            _databaseContext.SaveChanges();

            return userInDB;
        }

        public bool Delete(int id)
        {
            UserModel userInDB = FindId(id);

            if (userInDB == null) throw new ArgumentException("There was an error updating this user: This user does not exist.");


            _databaseContext.Users.Remove(userInDB);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<UserModel> GetAll()
        {
            return _databaseContext.Users.ToList();
        }

        public UserModel FindId(int id)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Id == id);
        }

    }
}
