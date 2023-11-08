using ContactRegistrationMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class UserModelNoPassword
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
    }
}
