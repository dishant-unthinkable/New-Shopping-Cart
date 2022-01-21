using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonModel person)
        {
            int personId = person.PersonId;
            string name = person.Name;
            string gender  = person.Gender;
            string city = person.City;
            Console.WriteLine(personId);
            Console.WriteLine(name);
            Console.WriteLine(gender);
            Console.WriteLine(city);

            return View();
        }
    }
}