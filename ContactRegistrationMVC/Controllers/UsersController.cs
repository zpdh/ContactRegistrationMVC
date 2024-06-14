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
                TempData["SuccessMsg"] = "User registered successfully!";
                user.RegistrationDate = DateTime.Now;
                _userRepository.Add(user);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error creating the user. Try again. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }
    }
}
