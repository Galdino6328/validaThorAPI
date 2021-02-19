using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
// Core Components
using MarcattiApi.Data;
using MarcattiApi.Models;
using MarcattiApi.Services;
using System;

namespace MarcattiApi.Controllers
{
    [Route("v1/users")]
    public class AuthLoginController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
                    [FromServices] DataContext context,
                    [FromBody]UserLogin model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Where(x => x.Email == model.Email && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user.Email,
                token = token
            };
        }
    }
}