using ContactRegistrationMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class PasslessUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The login field is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Please insert a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose a user type.")]
        public UserTypeEnum? UserType { get; set; }

    }
}
