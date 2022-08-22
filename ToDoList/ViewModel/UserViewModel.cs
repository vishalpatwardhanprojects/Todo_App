using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.ViewModel
{
    public class UserViewModel
    {
        public User UserDetails { get; set; }
        public List<User> UserListDetails { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}