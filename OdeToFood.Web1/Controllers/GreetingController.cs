using OdeToFood.Web1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web1.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            //Following is one way to access querystring in controller, but with MVC no need to access this
            //property directly instead pass name as parameter to method and mvc will try to populate it from querystring
            //var name = HttpContext.Request.QueryString["name"];
            model.name = name ?? "no name";
            
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }
    }
}