using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "The name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Please insert a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The phone number field is required.")]
        [Phone(ErrorMessage = "Please insert a valid phone number.")]
        public string PhoneNumber { get; set; }

        public int Id { get; set; }

        public ContactModel() { }

        public ContactModel(string name, string email, string phoneNumber, int id)
        {
            Name=name;
            Email=email;
            PhoneNumber=phoneNumber;
            Id=id;
        }
    }
}
