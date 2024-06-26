﻿using ContactRegistrationMVC.Enums;
using ContactRegistrationMVC.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate {  get; set; }
        public DateTime? UpdateDate { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The login field is required.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Please insert a valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose a user type.")]
        public UserTypeEnum? UserType { get; set; }
        [Required(ErrorMessage = "The password field is required.")]
        [PasswordPropertyText]
        public string Password { get; set; }

        public UserModel() { }

        public UserModel(int id, string name, string login, string email, UserTypeEnum? userType, string password)
        {
            Id=id;
            Name=name;
            Login=login;
            Email=email;
            UserType=userType;
            Password=password;
        }

        public bool ValidatePass(string password)
        {
            return Password.Equals(password.GenerateHash());
        }

        public void EncryptPass()
        {
            Password = Password.GenerateHash();
        }
    }
}
