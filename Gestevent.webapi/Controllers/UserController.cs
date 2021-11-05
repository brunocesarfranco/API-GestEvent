using System;
using System.Threading.Tasks;
using Gestevent.Core.Models;
using Gestevent.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestevent.webapi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository tickets)
        {
            _userRepository = tickets;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Post([FromBody] LoginFormModel registrationForm)
        {
            try
            {
                var user = new UserModel() 
                {
                    Username = registrationForm.Username,
                    Password = registrationForm.Password,
                    Role = "cliente",
                };
                await _userRepository.Add(user);
                return Ok(user);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> Get()
        {
            try
            {
                var user = await _userRepository.GetAll();
                return Ok(user);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(Guid id)
        {
            try
            {
                var user = await _userRepository.Get(id);
                return user is null ? NotFound() : Ok(user);
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpDelete]
        
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var wasDeletes = await _userRepository.Delete(id);
                return wasDeletes ? NoContent() : NotFound();
            }
            catch
            {
                return Problem("Service unavalable", statusCode: 500);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]    
        public async Task<ActionResult<dynamic>> Autenthicate ([FromBody] LoginFormModel loginForm)
        {
            try
            {
                var token = await _userRepository.Authenticate(loginForm);
                return token is null ? Problem("Usuário não encontrado", statusCode: 400) : Ok(token);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message + "Não foi possivel fazer login" });
            }
        }

    }
}
