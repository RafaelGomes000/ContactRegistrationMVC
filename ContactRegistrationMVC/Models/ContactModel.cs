using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ContactRegistrationMVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail not valid!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Phone(ErrorMessage = "Number not valid!")]
        public string Number { get; set; }
    }
}
