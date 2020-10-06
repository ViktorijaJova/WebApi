using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Todo.DataAccess;
using WebApi.Todo.DataModel;
using WebApi.Todo.Models;
using WebApi.Todo.Services.Exceptions;
using WebApi.Todo.Services.Interfaces;

namespace WebApi.Todo.Services
{
    public class TodoService : ITodoService
    {


        private readonly IRepository<User> _userRepository;
        private readonly IRepository<TodoList> _todoRepository;

        public TodoService(IRepository<User> userRepository, IRepository<TodoList> todoRepostiry)
        {
            this._userRepository = userRepository;
            this._todoRepository = todoRepostiry;
        }


        public void AddTodo(TodoModel request)
        {
            var user = _userRepository.GetAll()
                           .FirstOrDefault(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new TodoException("USer does not exist");
            }
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                throw new TodoException("Description is requiered");
            }
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new TodoException("Title is requied");
            }
            if (request.Completed != false && request.Completed != true)
            {
                throw new TodoException("Complision is required");
            }

            var todo = new TodoList
            {
                Id = request.Id,
                Title = request.Title,
                Description= request.Description,
                UserId = request.UserId,
                Completed = request.Completed
            };
            _todoRepository.Add(todo);
        }

        public void DeleteTodo(int id, int userId)
        {
            var item = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (item == null)
                throw new TodoException("ToDo item  was not found.");

            _todoRepository.Delete(item);
        }

        public TodoModel GetTodo(int id, int userId)
        {
            var item = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (item == null)
                throw new TodoException("Todo item was not found.");

            return new TodoModel
            {
                Id = item.Id,
                UserId = item.UserId,
                Completed = item.Completed,
                Description = item.Description,
                Title = item.Title
            };
        }

        public IEnumerable<TodoModel> GetUserTodos(int userId)
        {
            return _todoRepository.GetAll().Where(x => x.UserId == userId).Select(x => new TodoModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Completed = x.Completed,
                UserId = x.UserId
            }).ToList();
        }



        public void ChangeCompletenessStatus(int id, int userId)
        {
            var item = _todoRepository.GetAll().FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (item == null)
                throw new TodoException("Todo item was not found.");

            item.Completed = !item.Completed;

            _todoRepository.Update(item);
        }
    }
}
