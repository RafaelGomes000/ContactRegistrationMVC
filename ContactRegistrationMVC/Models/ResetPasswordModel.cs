﻿using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
