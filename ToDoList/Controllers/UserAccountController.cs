using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.ViewModel;
using ToDoList.Models.Repository;

namespace ToDoList.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                List<User> UserListDB = new List<User>();
                UserListDB.Add(new User { UserID = 1, Name = "Vishal", Username = "vishal", Password = "vishal123" });
                UserListDB.Add(new User { UserID = 2, Name = "Shekar", Username = "shekar", Password = "shekar123" });
                UserListDB.Add(new User { UserID = 3, Name = "Indranil", Username = "indranil", Password = "indranil123" });
                UserListDB.Add(new User { UserID = 4, Name = "Tanmay", Username = "tanmay", Password = "tanmay123" });
                UserListDB.Add(new User { UserID = 5, Name = "SuperUser", Username = "test", Password = "pwd123" });

                Session["UserListDetails"] = UserListDB;

                if (UserAccountBL.CheckValidUser(login))
                {
                    Session["UserDetails"] = UserListDB.Find(m => (m.Username == login.Username));
                    if (Session["TodoListDetails"] == null)
                    {
                        List<Todo> todolist = new List<Todo>();
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 1, TaskName = "Task1", CreatedBy = 1, CreatedDate = System.DateTime.Now, CreatedUser = "Vishal" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 2, TaskName = "Task2", CreatedBy = 2, CreatedDate = System.DateTime.Now, CreatedUser = "Shekar" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 3, TaskName = "Task3", CreatedBy = 1, CreatedDate = System.DateTime.Now, CreatedUser = "Vishal" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 4, TaskName = "Task4", CreatedBy = 3, CreatedDate = System.DateTime.Now, CreatedUser = "Indranil" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 5, TaskName = "Task5", CreatedBy = 4, CreatedDate = System.DateTime.Now, CreatedUser = "Tanmay" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 6, TaskName = "Task6", CreatedBy = 4, CreatedDate = System.DateTime.Now, CreatedUser = "Tanmay" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 7, TaskName = "Task7", CreatedBy = 3, CreatedDate = System.DateTime.Now, CreatedUser = "Indranil" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 8, TaskName = "Task8", CreatedBy = 3, CreatedDate = System.DateTime.Now, CreatedUser = "Indranil" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 9, TaskName = "Task9", CreatedBy = 2, CreatedDate = System.DateTime.Now, CreatedUser = "Shekar" });
                        todolist.Add(new Todo { IsActive = true, IsChecked = false, TaskID = 10, TaskName = "Task10", CreatedBy = 1, CreatedDate = System.DateTime.Now, CreatedUser = "Vishal" });
                        Session["TodoListDetails"] = todolist;
                    }
                    return Redirect("/Todo/List");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please enter a valid Username and Password.");
                    return View();
                }
            }
            else
            {
                return View(login);
            }
        }
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return Redirect("/UserAccount/Login");
        }

    }
}