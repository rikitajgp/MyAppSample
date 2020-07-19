using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;
using OdeToFood.Data.ViewModels;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
         IEnumerable<RestaurantViewModel> GetAll();
         RestaurantViewModel Get(int id);
        int Add(RestaurantViewModel restaurantViewModel);

       

        Restaurant CreateNew();

        IEnumerable<Weighter> GetAllWeighters();

        void Update(RestaurantViewModel restaurantViewModel);
        void Delete(int id);
    }
}
