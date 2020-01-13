using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        List<Restaurant> GetAll();

        List<Restaurant> GetByName(string name) => throw new NotImplementedException();

        Restaurant GetById(int id);
    }
}
