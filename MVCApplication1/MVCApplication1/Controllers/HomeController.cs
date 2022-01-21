using Microsoft.AspNetCore.Mvc;
using MVCApplication1.Models;
using System.Diagnostics;

namespace MVCApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Result r = new Result()
            {
                Name = "disha",
                Email="dishant.lodha@unthinkable.io"
            };
            return View(r);
        }
        [HttpPost]
        public ActionResult Result(Result r)
        {
           return View(r);  
        }
    }
}