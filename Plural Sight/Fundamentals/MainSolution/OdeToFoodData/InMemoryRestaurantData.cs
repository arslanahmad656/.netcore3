﻿using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "MarryLand", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "New York", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 3, Name = "Bombay Biryani", Location = "London", Cuisine = CuisineType.Indian}
            };

        }

        public Restaurant Add(Restaurant restaurant)
        {
            var toAdd = new Restaurant
            {
                Id = restaurants.Max(r => r.Id) + 1,
                Cuisine = restaurant.Cuisine,
                Location = restaurant.Location,
                Name = restaurant.Name
            };

            restaurants.Add(toAdd);
            return toAdd;
        }

        public int Commit() => 0;

        public Restaurant Delete(int id)
        {
            var toDelete = restaurants.SingleOrDefault(r => r.Id == id);
            restaurants.Remove(toDelete);
            return toDelete;
        }

        public List<Restaurant> GetAll() => restaurants;

        public Restaurant GetById(int id) => restaurants.SingleOrDefault(r => r.Id == id);

        public List<Restaurant> GetByName(string name) 
            => string.IsNullOrWhiteSpace(name) ? restaurants : restaurants.Where(r => r.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

        public Restaurant Update(Restaurant restaurant)
        {
            var toUpdate = restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
            if (toUpdate != null)
            {
                toUpdate.Name = restaurant.Name;
                toUpdate.Location = restaurant.Location;
                toUpdate.Cuisine = restaurant.Cuisine;
            }

            return toUpdate;
        }
    }
}
