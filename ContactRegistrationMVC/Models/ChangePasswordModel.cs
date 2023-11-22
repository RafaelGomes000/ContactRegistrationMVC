using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the user's current password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Enter the user's new password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm the user's new password")]
        [Compare("NewPassword", ErrorMessage = "Password does not match new password")]
        public string ConfirmNewPassword { get; set; }
    }
}
