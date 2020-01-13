using OdeToFoodCore;
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
                new Restaurant { Id = 1, Name = "Cinnamon Club", Location = "New York", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 1, Name = "Bombay Biryani", Location = "London", Cuisine = CuisineType.Indian}
            };

        }

        public List<Restaurant> GetAll() => restaurants;

        public List<Restaurant> GetByName(string name) 
            => string.IsNullOrWhiteSpace(name) ? restaurants : restaurants.Where(r => r.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }
}
