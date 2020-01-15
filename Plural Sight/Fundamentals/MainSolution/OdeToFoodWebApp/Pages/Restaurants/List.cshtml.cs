using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFoodCore;
using OdeToFoodData;

namespace OdeToFoodWebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public List<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Term { get; set; }

        [TempData]
        public string RestaurantName { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("DFKLSJDFKLSJKLSJDFSKLJFDLKJFDLSKFJDSLFJDSLK");
            Restaurants = restaurantData.GetByName(Term);
        }
    }
}
