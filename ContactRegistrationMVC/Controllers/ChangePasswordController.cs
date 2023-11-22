using ContactRegistrationMVC.Helper;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactRegistrationMVC.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;

        public ChangePasswordController(IUserRepository userRepository, ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePasswordModel)
        {
            try
            {
                UserModel userLogged = _session.FindUserSession();
                changePasswordModel.Id = userLogged.Id;

                if (ModelState.IsValid)
                {
                    _userRepository.ChangePassword(changePasswordModel);
                    TempData["SuccessMessage"] = "Password changed successfully";
                    return View("Index", changePasswordModel);
                }

                return View("Index", changePasswordModel);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"{e.Message}";
                return View("Index", changePasswordModel);
            }
        }
    }
}
