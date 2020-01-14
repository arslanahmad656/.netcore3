using Microsoft.EntityFrameworkCore;
using OdeToFoodCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodData
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
