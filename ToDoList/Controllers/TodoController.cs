using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.ViewModel;
using ToDoList.Models.BusinessLayer;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult List()
        {
            User UserInfo = Session["UserDetails"] as User;
            
            TodoViewModel tvm = new TodoViewModel();
            List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            ViewBag.UserName = UserInfo.Name;
            if(UserInfo.UserID==5)
                tvm.TodoListDetails = todolist.FindAll(m => (m.IsActive == true)).OrderBy(m => m.IsChecked).ToList();
            else
                tvm.TodoListDetails = todolist.FindAll(m => (m.IsActive == true && m.CreatedBy== UserInfo.UserID)).OrderBy(m => m.IsChecked).ToList();

            return View(tvm);
        }
        public ActionResult GetTask(int listIndex)
        {
            TodoViewModel tvm = new TodoViewModel();
            List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            tvm.TodoDetails = todolist.Find(m => (m.TaskID == listIndex));
            return Json(tvm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddTask(string TaskName)
        {
            bool success=TodoBL.AddTask(TaskName);
            //TodoViewModel tvm = new TodoViewModel();
            //List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            //User UserInfo = Session["UserDetails"] as User;
            ////New Task below
            //int newtaskid = todolist.FindAll(m => (m.IsActive == true)).Count()+1;
            //todolist.Add(new Todo { IsChecked = false, TaskID = newtaskid, TaskName = TaskName, CreatedBy = UserInfo.UserID, CreatedDate = System.DateTime.Now, CreatedUser = UserInfo.Name, IsActive = true });
            //Session["TodoListDetails"] = todolist;
            //tvm.TodoListDetails = todolist;
            
            return Json(success, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateTask(int listIndex, string TaskName,string Desc)
        {
            bool success = TodoBL.UpdateTask(listIndex,TaskName,Desc);
            //TodoViewModel tvm = new TodoViewModel();
            //List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            //User UserInfo = Session["UserDetails"] as User;
            //tvm.TodoListDetails = todolist;
            //tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoDetails.TaskName = TaskName;
            //tvm.TodoDetails.ModifiedDesc = Desc;
            //tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
            //tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
            //tvm.TodoDetails.ModifiedUser = UserInfo.Name;
            //var task=tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoListDetails.Remove(task);
            //todolist.Add(tvm.TodoDetails);
            //Session["TodoListDetails"] = todolist;
            
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveTask(int listIndex, string Desc) // Flag 1 = EDIT MODEL POPUP OR Flag 0 = NEW MODEL POPUP
        {
            bool success = TodoBL.RemoveTask(listIndex, Desc);
            //TodoViewModel tvm = new TodoViewModel();
            //List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            //User UserInfo = Session["UserDetails"] as User;
            //tvm.TodoListDetails = todolist;
            //tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoDetails.ModifiedDesc = Desc;
            //tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
            //tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
            //tvm.TodoDetails.ModifiedUser = UserInfo.Name;
            //tvm.TodoDetails.IsActive = false;

            //var task = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoListDetails.Remove(task);
            //tvm.TodoListDetails.Add(tvm.TodoDetails);
            //todolist.Add(tvm.TodoDetails);

            //Session["TodoListDetails"] = todolist;
            
            return Json(success, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IsCheck(int listIndex, bool isCheck) // Flag 1 = EDIT MODEL POPUP OR Flag 0 = NEW MODEL POPUP
        {
            bool success = TodoBL.IsCheck(listIndex, isCheck);
            //TodoViewModel tvm = new TodoViewModel();
            //List<Todo> todolist = Session["TodoListDetails"] as List<Todo>;
            //User UserInfo = Session["UserDetails"] as User;
            //tvm.TodoListDetails = todolist;
            //tvm.TodoDetails = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoDetails.IsChecked = isCheck;
            //tvm.TodoDetails.ModifiedDate = System.DateTime.Now;
            //tvm.TodoDetails.ModifiedBy = UserInfo.UserID;
            //tvm.TodoDetails.ModifiedUser = UserInfo.Name;
            
            //var task = tvm.TodoListDetails.Find(m => (m.TaskID == listIndex));
            //tvm.TodoListDetails.Remove(task);
            //tvm.TodoListDetails.Add(tvm.TodoDetails);
            //Session["TodoListDetails"] = todolist;
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}