
using NewShoppingCart.Models;
using System.Diagnostics;
using System.Collections.Generic;
//using System.Web.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;

namespace NewShoppingCart.Controllers
{
    [Authorize]
    //[CustomFilter]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            TempData.Keep("cartItems");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
        
        public new ActionResult User()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            TempData.Keep("cartItems");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
        public ActionResult Contact()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult AboutUs()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }
    }
}