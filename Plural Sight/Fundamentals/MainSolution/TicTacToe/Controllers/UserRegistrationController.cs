﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Controllers
{
    public class UserRegistrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}