using Microsoft.AspNetCore.Mvc;

namespace NewShoppingCart.Controllers
{
    public class PaymentStatusController : Controller
    {
        public ActionResult Success()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            return View();
        }
        public ActionResult Failed()
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            return View();
        }
    }
}
