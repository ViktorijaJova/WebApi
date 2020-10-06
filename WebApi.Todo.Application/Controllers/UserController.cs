using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Todo.Models;
using WebApi.Todo.Services.Exceptions;
using WebApi.Todo.Services.Interfaces;

namespace WebApi.Todo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult<UserModel> Authenticate([FromBody] LoginModel request)
        {
            try
            {
                var response = _userService.Authenticate(request.UserName, request.Password);

                Debug.WriteLine($"{response.Id} has been loged in");
                return Ok(response);
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User: {ex.UserId}, {ex.Name} {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrateModel request)
        {
            try
            {
                _userService.Register(request);
                Debug.WriteLine($"User registred with {request.UserName}");
                return Ok("Success");
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User {ex.UserId} ,{ex.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}
