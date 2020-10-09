using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Todo.DataModel;

namespace WebApi.Todo.DataAccess.EntityFramework
{


 public class SubTasksRepository : IRepository<SubTask>
    {
        private readonly TodosDbContext _context;

    public SubTasksRepository(TodosDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SubTask> GetAll()
    {
        return _context.SubTasks;
    }

        public void Update(SubTask entity)
        {
            _context.SubTasks.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(SubTask entity)
        {
            _context.SubTasks.Remove(entity);
            _context.SaveChanges();
        }

        public SubTask GetById(int id)
    {
        return _context.SubTasks.FirstOrDefault(x => x.Id == id);
    }

    public void Add(SubTask entity)
    {
        _context.SubTasks.Add(entity);
        _context.SaveChanges();
    }

 

}
}
