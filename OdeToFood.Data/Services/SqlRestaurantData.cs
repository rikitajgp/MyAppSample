using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;
using OdeToFood.Data.ViewModels;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext  db;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public int Add(RestaurantViewModel restaurantViewModel)
        {

            Restaurant restaurant = new Restaurant();
            //restaurant.Name = restaurantViewModel.Name;
            //restaurant.WeighterId = restaurantViewModel.selectedWeighterId;
            //restaurant.Cuisine = restaurantViewModel.Cuisine;

            restaurant = AutoMapper.Mapper.Map<RestaurantViewModel, Restaurant>(restaurantViewModel);
            restaurant.Id = db.Restaurants.Max(r => r.Id) + 1;
            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return restaurant.Id;
        }

        public Restaurant CreateNew()
        {
           Restaurant restaurant =  db.Restaurants.Create();
            //restaurant.Weighters = GetWeighters();
            return restaurant;
        }

        public IEnumerable<Weighter> GetAllWeighters()
        {
            return db.Weighters;
        }

        public void Delete(int id)
        {
            var restaurant=  db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public RestaurantViewModel Get(int id)
        {
           Restaurant restaurant = db.Restaurants.FirstOrDefault(r => r.Id == id);
            //RestaurantViewModel restaurantViewModel = new RestaurantViewModel();
            //restaurantViewModel.Id = restaurant.Id;
            //restaurantViewModel.Name = restaurant.Name;
            //restaurantViewModel.selectedWeighterId = restaurant.WeighterId;
            RestaurantViewModel restaurantViewModel=  AutoMapper.Mapper.Map<Restaurant, RestaurantViewModel>(restaurant);
            return restaurantViewModel;
        }

        public IEnumerable<RestaurantViewModel> GetAll()
        {
            //return db.Restaurants;
            //var restaurants= from r in db.Restaurants
            //       orderby r.Name
            //       select r;

            var restaurants = db.Restaurants.ToList();

            var restaurantViewModels = AutoMapper.Mapper.Map<List<Restaurant>, List<RestaurantViewModel>>(restaurants);
            return restaurantViewModels;
        }



        public void Update(RestaurantViewModel restaurantViewModel)
        {
            //var r = Get(restaurant.Id);
            //r.Name = restaurant.Name;
            //db.SaveChanges();

            //var entry = db.Entry(restaurant);
            //entry.State = EntityState.Modified;
            //db.SaveChanges();

            Restaurant restaurant = db.Restaurants.FirstOrDefault(r => r.Id == restaurantViewModel.Id);
            //restaurant.Name = restaurantViewModel.Name;
            //restaurant.WeighterId = restaurantViewModel.selectedWeighterId;
            //restaurant.Cuisine = restaurantViewModel.Cuisine;
            restaurant= AutoMapper.Mapper.Map<RestaurantViewModel,Restaurant>(restaurantViewModel);
            //var entry = db.Entry(restaurant);
            //entry.State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
