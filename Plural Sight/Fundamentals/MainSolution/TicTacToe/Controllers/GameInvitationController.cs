using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;
using TicTacToe.Services;

namespace TicTacToe.Controllers
{
    public class GameInvitationController : Controller
    {
        private readonly IUserService _userService;

        public GameInvitationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid invitedBy)
        {
            var invitingUser = await _userService.GetUserById(invitedBy);
            var invitationModel = new GameInvitationModel
            {
                InvitedBy = invitingUser.Email
            };

            return View(invitationModel);
        }
    }
}