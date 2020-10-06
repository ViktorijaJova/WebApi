using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Todo.DataModel;

namespace WebApi.Todo.DataAccess.EntityFramework
{
  public  class UserRepository : IRepository<User>
    {
        private readonly TodosDbContext _context;

        public UserRepository(TodosDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
            
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
