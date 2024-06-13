using Microsoft.AspNetCore.Mvc;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repositories;
using ContactRegistrationMVC.Data;

namespace ContactRegistrationMVC.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepo)
        {
            _contactRepository = contactRepo;
        }

        public IActionResult Index()
        {
            var contacts = _contactRepository.GetAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Add(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {

            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}

