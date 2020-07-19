﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Weighter> Weighters { get; set; }

        public System.Data.Entity.DbSet<OdeToFood.Data.ViewModels.RestaurantViewModel> RestaurantViewModels { get; set; }
    }
}
