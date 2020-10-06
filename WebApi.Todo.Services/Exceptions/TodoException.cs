using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Todo.Services.Exceptions
{
  public  class TodoException:Exception
    {
        public TodoException(string message) : base(message)
        {

        }
    }
}
