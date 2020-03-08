using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToe.Middleware
{
    public class CommunicationsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public CommunicationsMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Equals("/CheckEmailConfirmationStatus"))
            {
                var email = context.Request.Query["email"];
                await _userService.ConfirmEmail(email);
                await context.Response.WriteAsync("ok");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
