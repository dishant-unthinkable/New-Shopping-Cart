using IOCIntro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IOCIntroBAL;

namespace IOCIntro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIOCIntro _iOCIntro;
        public HomeController(IIOCIntro iOCIntro)
        {
            _iOCIntro = iOCIntro;
        }
        public int Index()
        {
            return _iOCIntro.GetStudentCount();
        }
    }
}