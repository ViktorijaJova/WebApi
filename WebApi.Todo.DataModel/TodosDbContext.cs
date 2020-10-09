using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Todo.DataModel
{
   public class TodosDbContext : DbContext
    {
        public TodosDbContext(DbContextOptions opt)
            : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public DbSet<TodoList> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // User
            modelBuilder.Entity<User>()
                .ToTable(nameof(User))
                .HasKey(p => p.Id);




            modelBuilder.Entity<User>()
                .Property(p => p.UserName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired();

            //Todo

            modelBuilder.Entity<TodoList>()
                .ToTable(nameof(TodoList))
                .HasKey(p => p.Id);

            modelBuilder.Entity<TodoList>()
                .Property(p => p.Description)
                .HasMaxLength(150);

            modelBuilder.Entity<TodoList>()
                .Property(p => p.Title)
                .HasMaxLength(20);


            modelBuilder.Entity<TodoList>()
                .HasOne(p => p.User)
                .WithMany(p => p.TodoList)
                .HasForeignKey(p => p.UserId);


            //SubTask
            modelBuilder
             .Entity<SubTask>()
             .ToTable(nameof(SubTask))
             .HasKey(x => x.Id);

            modelBuilder
                .Entity<SubTask>()
                .HasOne(x => x.ToDoTask)
                .WithMany(x => x.SubTasks)
                .HasForeignKey(x => x.Id);




            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Viktorija",
                    LastName = "jovanovska",
                    UserName = "ViktorijaJ",
                    Password = hashedPassword
                });
            modelBuilder.Entity<TodoList>()
                .HasData(
                new TodoList()
                {
                    Id = 1,
                    Description = "Buy Juice",
                    Title = "do this",
                    Completed = false,
                    UserId = 1
                },
                new TodoList()
                {
                    Id = 2,
                    Description = "Learn ASP.NET Core WebApi",
                    Title = "and this",
                    Completed = false,
                    UserId = 1
                },
                  modelBuilder.Entity<SubTask>()
                .HasData(
                new SubTask()
                {
                    Id = 1,
                    Name = "Finish the homework already",
                    
                }
                ));
        }
    }
}
