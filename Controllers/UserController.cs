using AIRBNB.Models;
using AIRBNB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AIRBNB.Controllers
{
    public class UserController : Controller
    {
        private readonly InterfaceUserRole _userRpository;

        public UserController(InterfaceUserRole userRepository)
        {
            _userRpository = userRepository;
        }
        
        public IActionResult Index() //pode ser a pagina com as infos do perfil do usuario
        {
            List<UserModel> users = _userRpository.FindAllUsers();

            return View(users);
        }


        [HttpPost]
        public IActionResult Create(UserModel user) 
        {
            _userRpository.AddNewUser(user);
            return RedirectToAction("Index"); //tem que retornar para a pagina index, onde esta as infos recem criadas
        }
    }
}
