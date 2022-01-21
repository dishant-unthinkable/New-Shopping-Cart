
using ShoppingCart.Models;
using System.Diagnostics;
using System.Collections.Generic;
//using System.Web.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;

namespace ShoppingCart.Controllers
{
    
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
        public new ActionResult User()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}