using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Todo.Models;
using WebApi.Todo.Services.Exceptions;
using WebApi.Todo.Services.Interfaces;

namespace WebApi.Todo.Application.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoservice;
        public TodoController(ITodoService todoservice)
        {
            this._todoservice = todoservice;
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoModel request)
        {
            try
            {
                _todoservice.AddTodo(request);
                return Ok("Success");
            }
            catch (TodoException ex)
            {

                Debug.WriteLine($"Todo {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {


                Debug.WriteLine($"Todo {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
      
    }
}
