using AIRBNB.Data;
using AIRBNB.Models.DTOs.Users;
using AIRBNB.Models.Entities;
using AIRBNB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace AIRBNB.Controllers
{
    [ApiController]
    [Route("api/'[controller]")]
    public class AuthController : Controller
    {

        private readonly DataBaseContext _context;
        private readonly AuthService _authService;

        public AuthController(DataBaseContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto dto)
        {
            if (_context.Users.Any(u => u.UserName == dto.Username))
                return BadRequest("User already exists!");

            var user = new UserModel
            {
                UserName = dto.Username,
                Email = dto.Email,
                PasswordHash = _authService.HashPassword(dto.Password),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successful!");
        }

        [HttpPost("login")]

        public IActionResult Login(UserLoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == dto.Username);

            if (user == null || !_authService.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalide Username or Password!");

            return Ok("Login successful");
        }
    }
}
