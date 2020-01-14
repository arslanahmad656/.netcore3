using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public List<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Term { get; set; }

        [TempData]
        public string RestaurantName { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Restaurants = restaurantData.GetByName(Term);
        }
    }
}
