using ContactRegistrationMVC.Helper;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;
        public LoginController(IUserRepository userRepository, ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            //if user is already logged in, redirect to home page
            if(_session.FindUserSession() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            _session.RemoveUserSession();
            return RedirectToAction("Index", "Login");
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
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = $"Wrong password.";
                    }

                    TempData["ErrorMessage"] = $"Wrong username or password.";
                }
                return View("Index");
            }
            catch (Exception e)
            {

                TempData["ErrorMessage"] = $"An error has occurred, details: {e.InnerException.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult LinkToResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.FindByEmailAndLogin(resetPasswordModel.Email, resetPasswordModel.Login);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();
                        _userRepository.Update(user);

                        TempData["SuccessMessage"] = $"We send you a new password in your registered email address.";
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["ErrorMessage"] = $"Wrong username or email.";
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
