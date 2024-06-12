using Microsoft.AspNetCore.Mvc;
using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            HashSet<Contact> contacts = new HashSet<Contact>();
            contacts.Add(new Contact("Bob Brown", "bobbrown@gmail.com", "12345-6789", 1));
            contacts.Add(new Contact("Sean Wave", "seanwave@gmail.com", "98765-4321", 2));
            contacts.Add(new Contact("Richard Aston", "richaston@gmail.com", "56789-1234", 3));

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
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

