using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Controllers
{
    public class LearningController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hi there!");
        }

        public IActionResult OptOutOfTagHelperTest()
        {
            return View(new Movie
            {
                ID = 4578,
                Title = "SAW VII",
                //ReleaseDate = new DateTime(2007, 12, 11),
                Genre = "Thriller",
                Price = 455.98M
            });
        }
    }
}