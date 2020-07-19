using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OdeToFood.Data.ViewModels
{
    public class RestaurantViewModel 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Type of Food")]
        public CuisineType Cuisine { get; set; }
        public int WeighterId { get; set; }
        public int selectedWeighterId { get; set; }
        public IEnumerable<SelectListItem> weighters { get; set; }        

    }
}
