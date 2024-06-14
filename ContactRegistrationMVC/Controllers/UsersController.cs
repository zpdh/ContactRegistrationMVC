using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
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
        //These methods get called when you save, edit or delete a contact
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                user.RegistrationDate = DateTime.Now;
                _userRepository.Add(user);
                TempData["SuccessMsg"] = "User registered successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error creating the user. Try again. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                _userRepository.Update(user);
                TempData["SuccessMsg"] = "User edited successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error editing the user. Try again. (Error details: {e.Message})";
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
                TempData["ErrorMsg"] = $"There was an error deleting the user. Try again. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }
    }
}
