using ContactRegistrationMVC.Helper;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _session;

        public LoginController(IUserRepository userRepository, IUserSession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            //If user is logged in, redirect to home instead of login page

            if (_session.FindSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult LogOff()
        {
            _session.EndSession();
            return RedirectToAction("Index", "Login");
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
                    _session.StartSession(user);
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
