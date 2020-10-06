using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Todo.Models;

namespace WebApi.Todo.Services.Interfaces
{
   public interface ITodoService
    {
        IEnumerable<TodoModel> GetUserTodos(int userId);

        TodoModel GetTodo(int id, int userId);
        void AddTodo(TodoModel request);
        void DeleteTodo(int id, int userId);
        void ChangeCompletenessStatus(int id, int userId);


    }
}
