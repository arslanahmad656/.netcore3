using Microsoft.AspNetCore.Mvc;
using OdeToFoodData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodWebApp.ViewComponents
{
    public class RestaurantCountViewModel : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            return View(restaurantData.GetAll().Count);
        }
    }
}
