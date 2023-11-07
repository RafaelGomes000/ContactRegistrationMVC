using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Create(user);
                    TempData["SuccessMessage"] = "Successfully registered";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (System.Exception e)
            {
                TempData["ErrorMessage"] = $"An error ocurred, details: {e.InnerException.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
