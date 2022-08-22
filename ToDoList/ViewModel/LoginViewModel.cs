using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.ViewModel
{
    public class LoginViewModel
    {
        public Login LoginDetails { get; set; }
    }
    public class Login
    {
        [Required(ErrorMessage = "Username Required")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}