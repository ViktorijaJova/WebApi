using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.DataModel
{
  public  class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public IEnumerable<SubTask> SubTasks { get; set; }

    }
}
