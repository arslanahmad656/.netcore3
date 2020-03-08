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
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            userModel.Id = Guid.NewGuid();
            await _userService.CreateUser(userModel);
            return RedirectToAction(nameof(EmailConfirmation), new { emailAddress = userModel.Email });
        }

        [HttpGet]
        public async Task<IActionResult> EmailConfirmation(string emailAddress)
        {
            var user = await _userService.GetUserByEmail(emailAddress);
            if (user?.IsEmailConfirmed == true)
            {
                return RedirectToAction(nameof(Index), nameof(GameInvitationController).Remove(nameof(GameInvitationController).IndexOf("Controller")), new { invitedBy = user.Id });
            }

            user.IsEmailConfirmed = true;
            user.EmailConfirmationDate = DateTime.Now;
            await _userService.UpdateUser(user);

            ViewBag.Email = emailAddress;
            return View();
        }
    }
}
