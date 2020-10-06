using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApi.Todo.DataAccess;
using WebApi.Todo.DataModel;
using WebApi.Todo.Models;
using WebApi.Todo.Services.Exceptions;
using WebApi.Todo.Services.Interfaces;

namespace WebApi.Todo.Services
{
  public  class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public UserModel Authenticate(string username, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                throw new UserException(null, null, "User with that username does not excist");
            }
            var hashedPassword = HashPassword(password);
            if (user.Password != hashedPassword)
            {
                throw new UserException(user.Id, user.Password, "User password does not match with user");
            }
            //Todo: create aut token
            var userModel = new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Id = user.Id
            };

            return userModel;

        }

        public void Register(RegistrateModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                throw new UserException(null, request.Password,
                    "Password is required");
            }

            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException(null, request.Password,
                    "Passwords does not match");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new UserException(null, request.FirstName,
                    "Firstname is required"); // should use custom exception
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new UserException(null, request.LastName,
                    "Lastname is required");
            }

            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                throw new UserException(null, request.UserName,
                    "Username is required");
            }

            var hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = hashedPassword
            };

            _userRepository.Add(user);
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5data);
        }
    }
}
