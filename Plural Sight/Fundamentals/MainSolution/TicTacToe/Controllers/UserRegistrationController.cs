using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;
using TicTacToe.Services;

namespace TicTacToe.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserService _userService;

        public UserRegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserModel userModel)
        {
            await _userService.RegisterUser(userModel);
            return Content($"{userModel.FirstName} {userModel.LastName} registered.");
        }
    }
}
