using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCore;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        
        public void OnGet(int restaurantId)
        {
            Restaurant = new Restaurant
            {
                Cuisine = CuisineType.None,
                Id = restaurantId,
                Location = "Somewhere",
                Name = "My Restaurant"
            };
        }
    }
}
