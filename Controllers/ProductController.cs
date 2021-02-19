using validaThorAPI.Models;
using validaThorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace validaThorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _usersService;

        public UserController(UserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() => _usersService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _usersService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _usersService.Get(id);

            if (user == null)
                return NotFound();

            _usersService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
                return NotFound();

            _usersService.Remove(user.Id);

            return NoContent();
        }
    }
}