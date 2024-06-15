using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Filters;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    [AdminOnlyPage]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var user = _userRepository.FindId(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _userRepository.FindId(id);
            return View(user);
        }
        //These methods get called when you save, edit or delete a user
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                user.Login = user.Login.ToLower().Trim();
                user.RegistrationDate = DateTime.Now;

                if (_userRepository.SearchByLogin(user.Login) != null) {
                    throw new InvalidOperationException("There is already an user with that login.");
                }
                _userRepository.Add(user);
                TempData["SuccessMsg"] = "User registered successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error creating the user. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(PasslessUserModel passless)
        {
            try
            {
                UserModel user = new UserModel() { Id = passless.Id, Email = passless.Email, Login = passless.Login, Name = passless.Name, UserType = passless.UserType };
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                user.Login = user.Login.ToLower();
                user.UpdateDate = DateTime.Now;
                _userRepository.Update(user);
                TempData["SuccessMsg"] = "User edited successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error editing the user. (Error details: {e.InnerException})";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Del(int id)
        {
            try
            {
                _userRepository.Delete(id);
                TempData["SuccessMsg"] = "User deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error deleting the user. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }
    }
}
