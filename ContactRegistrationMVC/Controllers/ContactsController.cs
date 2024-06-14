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

        public IActionResult Edit(int id)
        {
            var contact = _contactRepository.FindId(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.FindId(id);
            return View(contact);
        }

        //These methods get called when you save, edit or delete a contact
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contact);
                }
                _contactRepository.Add(contact);
                TempData["SuccessMsg"] = "Contact registered successfully!";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error creating the contact. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contact);
                }
                TempData["SuccessMsg"] = "Contact edited successfully!";
                _contactRepository.Update(contact);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error editing the contact. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Del(int id)
        {
            try
            {
                _contactRepository.Delete(id);
                TempData["SuccessMsg"] = "Contact deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMsg"] = $"There was an error deleting the contact. (Error details: {e.Message})";
                return RedirectToAction("Index");
            }
        }
    }
}

