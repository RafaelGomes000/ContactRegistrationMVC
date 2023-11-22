using ContactRegistrationMVC.Filters;
using ContactRegistrationMVC.Helper;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    [PageForLoggedUser]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISession _session;

        public ContactController(IContactRepository contactRepository, ISession session)
        {
            _contactRepository = contactRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            UserModel userLogged = _session.FindUserSession();
            var contacts = _contactRepository.GetAll(userLogged.Id);
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var contact = _contactRepository.ListId(id);
            return View(contact);
        }

        public IActionResult Remove(int id)
        {
            var contact = _contactRepository.ListId(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _contactRepository.Delete(id);
                TempData["SuccessMessage"] = "Contact deleted";
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["ErrorMessage"] = $"An error has occurred, details: {e.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogged = _session.FindUserSession();
                    contact.UserId = userLogged.Id;

                    contact = _contactRepository.Create(contact);
                    TempData["SuccessMessage"] = "Successfully registered";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["ErrorMessage"] = $"An error has occurred, details: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel userLogged = _session.FindUserSession();
                    contact.UserId = userLogged.Id;

                    contact = _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contact updated";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["ErrorMessage"] = $"An error has occurred, details: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
