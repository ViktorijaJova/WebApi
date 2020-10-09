using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.DataModel
{
  public  class SubTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TodoList ToDoTask { get; set; }

    }
}
