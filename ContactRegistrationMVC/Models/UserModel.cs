using ContactRegistrationMVC.Enums;
using ContactRegistrationMVC.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail not valid!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Profile type is required")]
        public ProfileEnum? Profile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool PasswordIsValid(string password)
        {
            return Password == password.GenerateHash();
        }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }

        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.GenerateHash();
            return newPassword;
        }
    }
}
