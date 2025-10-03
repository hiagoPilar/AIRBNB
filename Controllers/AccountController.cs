using AIRBNB.Data;
using AIRBNB.Models.DTOs.Users;
using AIRBNB.Models.Entities;
using AIRBNB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIRBNB.Controllers
{
    public class AccountController : Controller
    {

        private readonly DataBaseContext _context;
        private readonly AuthService _authService;

        public AccountController(DataBaseContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto dto)
        {

            var user = _context.Users.FirstOrDefault(u => u.UserName == dto.Username);
            if (user == null || !_authService.VerifyPassword(dto.Password, user.PasswordHash))
            {
                ViewBag.Error = "Invalide Username or Password!";
                return View();
            }

            TempData["Successful"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {
            if(_context.Users.Any(u => u.UserName == dto.Password))
            {
                ViewBag.Error = "User already exists!";
                return View();
            }

            var user = new UserModel
            {
                UserName = dto.Username,
                Email = dto.Email,
                PasswordHash = _authService.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Success"] = "Registration completed successful!";
            return RedirectToAction("Login");
        }
    }
}
