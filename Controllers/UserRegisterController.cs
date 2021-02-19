using System;
using MarcattiApi.Data;
using MarcattiApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
// Core Components
using MarcattiApi.Services;

namespace MarcattiApi.Controllers
{
    [Route("v1/users")]
    public class AuthRegisterController : Controller
    {
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserRegister>> Post(
            [FromServices] DataContext context,
            [FromBody]UserRegister model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();

                return Ok("Usuário Cadastrado");
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }    
    }
}