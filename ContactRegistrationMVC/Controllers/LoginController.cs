using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", loginModel);
                }
                UserModel user = _userRepository.SearchByLogin(loginModel.Login);
                if (user != null && user.ValidatePass(loginModel.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                throw new ArgumentException("Invalid username and/or password. Try again.");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error logging into the account. (Error details: {e.Message})";
                return View("Index", loginModel);
            }
        }
    }
}
