using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The login field is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        public string Password { get; set; }
    }
}
