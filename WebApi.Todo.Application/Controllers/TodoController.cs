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
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get([FromQuery] int id)
        {
            try
            {
                return Ok(_todoService.GetUserTodos(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("post-todo")]
       public ActionResult Post([FromBody] TodoModel request)
        {
            try
            {
                _todoService.AddTodo(request);
                return Ok("Success");
            }
            catch (TodoException ex)
            {
                Debug.WriteLine($"Todo: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Todo: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TodoModel> Get(int id, [FromQuery] int userId)
        {
            try
            {
                return Ok(_todoService.GetTodo(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromQuery] int userId)
        {
            try
            {
                _todoService.DeleteTodo(id, userId);
                return Ok("Todo item has been  deleted");
            }
            catch (TodoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    }
