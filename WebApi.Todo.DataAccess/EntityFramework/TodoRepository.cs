using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Todo.DataModel;

namespace WebApi.Todo.DataAccess.EntityFramework
{
    public class TodoRepository:IRepository<TodoList>

    {
        private readonly TodosDbContext _context;
    public TodoRepository(TodosDbContext context)
    {
        _context = context;
    }
    public IEnumerable<TodoList> GetAll()
    {
        return _context.Todos;
        //  _context.SaveChanges();
    }

    public void Add(TodoList entity)
    {
        _context.Todos.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(TodoList entity)
    {
        _context.Todos.Remove(entity);
        _context.SaveChanges();

    }

    public void Update(TodoList entity)
    {
        _context.Todos.Update(entity);
        _context.SaveChanges();

    }
}
}
