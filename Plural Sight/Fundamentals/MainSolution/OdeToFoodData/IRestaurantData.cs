using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        List<Restaurant> GetAll();

        List<Restaurant> GetByName(string name);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant restaurant);

        int Commit();

        Restaurant Add(Restaurant restaurant);

        Restaurant Delete(int id);
    }
}
