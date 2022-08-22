using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.ViewModel;

namespace ToDoList.Models.BusinessLayer
{
    public class TodoBL
    {
        public static bool AddTask(string TaskName)
        {
            try
            {
                TodoViewModel tvm = new TodoViewModel();
                List<Todo> todolist = HttpContext.Current.Session["TodoListDetails"] as List<Todo>;
                User UserInfo = HttpContext.Current.Session["UserDetails"] as User;
                //New Task below
                int newtaskid = todolist.FindAll(m => (m.IsActive == true)).Count() + 1;
                todolist.Add(new Todo { IsChecked = false, TaskID = newtaskid, TaskName = TaskName, CreatedBy = UserInfo.UserID, CreatedDate = System.DateTime.Now, CreatedUser = UserInfo.Name, IsActive = true });
                HttpContext.Current.Session["TodoListDetails"] = todolist;
                tvm.TodoListDetails = todolist;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool UpdateTask(int listIndex, string TaskName, string Desc)
        {
            try
            {
                TodoViewModel tvm = new TodoViewModel();
                List<Todo> todolist = HttpContext.Current.Session["TodoListDetails"] as List<Todo>;
                User UserInfo = HttpContext.Current.Session["UserDetails"] as User;
                tvm.TodoListDetails = todolist;
                tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoDetails.TaskName = TaskName;
                tvm.TodoDetails.ModifiedDesc = Desc;
                tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
                tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
                tvm.TodoDetails.ModifiedUser = UserInfo.Name;
                var task = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoListDetails.Remove(task);
                todolist.Add(tvm.TodoDetails);
                HttpContext.Current.Session["TodoListDetails"] = todolist;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RemoveTask(int listIndex, string Desc)
        {
            try
            {
                TodoViewModel tvm = new TodoViewModel();
                List<Todo> todolist = HttpContext.Current.Session["TodoListDetails"] as List<Todo>;
                User UserInfo = HttpContext.Current.Session["UserDetails"] as User;
                tvm.TodoListDetails = todolist;
                tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoDetails.ModifiedDesc = Desc;
                tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
                tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
                tvm.TodoDetails.ModifiedUser = UserInfo.Name;
                tvm.TodoDetails.IsActive = false;

                var task = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoListDetails.Remove(task);
                tvm.TodoListDetails.Add(tvm.TodoDetails);
                todolist.Add(tvm.TodoDetails);

                HttpContext.Current.Session["TodoListDetails"] = todolist;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool IsCheck(int listIndex, bool isCheck)
        {
            try
            {
                TodoViewModel tvm = new TodoViewModel();
                List<Todo> todolist = HttpContext.Current.Session["TodoListDetails"] as List<Todo>;
                User UserInfo = HttpContext.Current.Session["UserDetails"] as User;
                tvm.TodoListDetails = todolist;
                tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoDetails.IsChecked = isCheck;
                tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
                tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
                tvm.TodoDetails.ModifiedUser = UserInfo.Name;

                var task = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
                tvm.TodoListDetails.Remove(task);
                tvm.TodoListDetails.Add(tvm.TodoDetails);
                HttpContext.Current.Session["TodoListDetails"] = todolist;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}