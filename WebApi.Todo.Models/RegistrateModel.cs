using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.Models
{
public    class RegistrateModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
