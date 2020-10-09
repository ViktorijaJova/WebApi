using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.Models
{
     public class TodoModel

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }

    }


}

