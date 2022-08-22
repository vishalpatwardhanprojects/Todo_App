using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.ViewModel
{
    public class TodoViewModel
    {
        public int? UserID { get; set; }
        public Todo TodoDetails { get; set; }
        public List<Todo> TodoListDetails { get; set; }
    }
    
    public class Todo
    {
        public bool IsChecked { get; set; }
        public int TaskID { get; set; }
        [Required(ErrorMessage = "Task Name Required")]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedDesc { get; set; }
        public bool? IsActive { get; set; }
    }
}