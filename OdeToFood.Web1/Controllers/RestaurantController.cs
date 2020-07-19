using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using OdeToFood.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web1.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData db;
        public RestaurantController(IRestaurantData db)
        {           
            this.db = db;
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
                return View("NotFound");

            return View(model); 
        }

        //[HttpGet]
        //public ActionResult Create()
        //{         

        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            RestaurantViewModel restaurantViewModel = new RestaurantViewModel();
            restaurantViewModel.weighters = db.GetAllWeighters().ToSelectListItems(-1);

            return View(restaurantViewModel);
        }       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantViewModel restaurantViewModel)
        {
            //Following is one way to check if error occured during modelBinding, ModelState is a collection, 
            //it will contain errors that occured during model binding for each property
            //it will also contain value that user entered for each property
            //ModelState["Name"].Value
            //ModelState["Name"].Errors

            //or you can explicity check value in property of model , 
            //if there is something wrong then you can explicitly populate model state with errors.
            if (string.IsNullOrEmpty(restaurantViewModel.Name))
            {
                ModelState.AddModelError(nameof(restaurantViewModel.Name), "The name is required");
            }


            if (ModelState.IsValid)
            {
                int Id= db.Add(restaurantViewModel);
                return RedirectToAction("Details", new { id = Id });
            }

            return View();
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var model = db.Get(id);

        //    if (model==null)
        //    {
        //        return HttpNotFound(); 
        //    }
        //    return View(model);
        //}


        //[HttpPost]
        //public ActionResult Edit(Restaurant restaurant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Update(restaurant);
        //        return RedirectToAction("Details", new {  id = restaurant.Id }); 
        //    }

        //    return View(restaurant);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            model.weighters = db.GetAllWeighters().ToSelectListItems(model.WeighterId);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(RestaurantViewModel restaurantViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurantViewModel);
                return RedirectToAction("Details", new { id = restaurantViewModel.Id });
            }

            return View(restaurantViewModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}