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

        public DbSet<TodoList> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
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
                .WithMany(p => p.Todos)
                .HasForeignKey(p => p.UserId);


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
                    FirstName = "Nikola",
                    LastName = "Jovanovski",
                    UserName = "NikolaJ",
                    Password = hashedPassword
                });
            modelBuilder.Entity<TodoList>()
                .HasData(
                new TodoList()
                {
                    Id = 1,
                    Title = "Buy groceries",
                    //Add subtasks
                    Description = "Go to the market and buy vegtables, bread, gin, cigarettes",
                    Completed = false,
                    UserId = 1
                },
                new TodoList()
                {
                    Id = 2,
                    Title = "Finally watch all the tv shows that you have wanted ",
                    //add subtasks
                    Description = "Watch breaking bad, the witcher and narcos",
                    Completed = false,
                    UserId = 1
                }
                );
        }
    }
}
