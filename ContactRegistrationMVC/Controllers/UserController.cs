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

        public IActionResult Edit(int id)
        {
            var user = _userRepository.ListId(id);
            return View(user);
        }

        public IActionResult Remove(int id)
        {
            var user = _userRepository.ListId(id);
            return View(user);
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
                TempData["ErrorMessage"] = $"An error has occurred, details: {e.InnerException.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
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
        public IActionResult Edit(UserModelNoPassword userNoPassword)
        {
            try
            {
                UserModel user = null;
                if (ModelState.IsValid)
                {

                    user = new UserModel()
                    {
                        Id = userNoPassword.Id,
                        Name = userNoPassword.Name,
                        Email = userNoPassword.Email,
                        Login = userNoPassword.Login,
                        Profile = userNoPassword.Profile
                    };

                    _userRepository.Update(user);
                    TempData["SuccessMessage"] = "User updated";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (System.Exception e)
            {
                TempData["ErrorMessage"] = $"An error has occurred, details: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
