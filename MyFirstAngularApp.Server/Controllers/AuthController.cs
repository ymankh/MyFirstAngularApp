using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstAngularApp.Server.DTOs.AuthDTOs;
using MyFirstAngularApp.Server.Helpers;
using MyFirstAngularApp.Server.Models;

namespace MyFirstAngularApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration config, GenerateJwtToken generateJwt, ApplicationDbContext context) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            var user = context.CustomUsers.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            // Validate the user credentials (replace with your own validation logic)
            if (user == null) return Unauthorized();
            var token = generateJwt.Generate(user.CustomUserId);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegister register)
        {
            var user = context.CustomUsers.FirstOrDefault(u => u.Email == register.Email);
            if (user != null) return Unauthorized();

            var newUser = new CustomUser
            {
                Email = register.Email,
                Password = register.Password,
                UserName = register.UserName
            };
            context.CustomUsers.Add(newUser);
            context.SaveChanges();
            return Created();
        }


    }
}
