namespace ContactRegistrationMVC.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; set; }

        public Contact() { }

        public Contact(string name, string email, string phoneNumber, int id)
        {
            Name=name;
            Email=email;
            PhoneNumber=phoneNumber;
            Id=id;
        }
    }
}
