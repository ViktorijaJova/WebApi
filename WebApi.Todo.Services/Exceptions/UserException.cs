using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.Services.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }

        public string Name { get; set; }

        public UserException(int? userId, string name) : base("There has been an issue with a user")
        {
            UserId = userId;
            Name = name;
        }
        public UserException(int? userId, string name, string message) : base(message)
        {
            UserId = userId;
            Name = name;
        }


    }
}
