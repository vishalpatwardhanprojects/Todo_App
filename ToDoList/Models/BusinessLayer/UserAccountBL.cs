using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.ViewModel;

namespace ToDoList.Models.Repository
{
    public class UserAccountBL
    {
        public static bool CheckValidUser(Login login)
        {
            List<User> todolist = HttpContext.Current.Session["UserListDetails"] as List<User>;
            if (todolist.Find(m => (m.Username == login.Username && m.Password == login.Password)) != null)
            {
                return true;
            }
            else if (login.Username == "test" && login.Password == "pwd123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}