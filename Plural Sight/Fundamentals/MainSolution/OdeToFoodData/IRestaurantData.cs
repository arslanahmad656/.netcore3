using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        List<Restaurant> GetAll();
    }
}
