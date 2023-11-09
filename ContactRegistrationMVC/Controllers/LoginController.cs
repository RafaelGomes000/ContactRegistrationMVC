using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UserModel user = _userRepository.FindByLogin(loginModel.Login);

                    if(user != null)
                    {
                        if (user.PasswordIsValid(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = $"Incorrect password";
                    }

                    TempData["ErrorMessage"] = $"Incorrect login or password";
                }
                return View("Index");
            }
            catch (Exception e)
            {

                TempData["ErrorMessage"] = $"An error has occurred, details: {e.InnerException.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
