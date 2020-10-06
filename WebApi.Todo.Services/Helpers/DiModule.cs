using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Todo.DataAccess;
using WebApi.Todo.DataAccess.EntityFramework;
using WebApi.Todo.DataModel;

namespace WebApi.Todo.Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {


            //registering db context
            services.AddDbContext<TodosDbContext>(x => x.UseSqlServer(connectionString));

            //register repositories

            //entity framework
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<TodoList>, TodoRepository>();


            return services;
        }
    }
}
