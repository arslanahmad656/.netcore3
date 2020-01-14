using Microsoft.EntityFrameworkCore;
using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            return dbContext.Add(restaurant).Entity;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = dbContext.Restaurants.Find(id);
            return dbContext.Remove(restaurant).Entity;
        }

        public List<Restaurant> GetAll()
        {
            return dbContext.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public List<Restaurant> GetByName(string name)
        {
            return string.IsNullOrWhiteSpace(name) ? GetAll() :
                dbContext.Restaurants.Where(r => r.Name.StartsWith(name)).ToList();
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = dbContext.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return entity.Entity;
        }
    }
}
