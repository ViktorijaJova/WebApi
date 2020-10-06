using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Todo.Models;

namespace WebApi.Todo.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegistrateModel request);
    }
}
