using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
