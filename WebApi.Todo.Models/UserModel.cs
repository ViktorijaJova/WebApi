using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.Models
{
   public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<TodoModel> ToDoList { get; set; }

        public UserModel()
        {
            ToDoList = new List<TodoModel>();
        }
    }
}
