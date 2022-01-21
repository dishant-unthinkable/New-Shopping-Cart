using Microsoft.AspNetCore.Mvc;
using ShoppingCartBAL;
using ShoppingCartBALObject;

namespace NewShoppingCart.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IProductBl _productBl;
        public OrderHistoryController(IProductBl productBl)
        {
            _productBl = productBl;
        }
        public ActionResult MyOrders(int UserId)
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            IEnumerable<OrderListObject> orderList = _productBl.GetOrderList(UserId);
            return View(orderList);
        }
        public ActionResult CancelOrder(int UserId, string OrderId)
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            _productBl.CancelOrder(UserId, OrderId);
            return RedirectToAction("MyOrders", new {UserId = UserId});
        }
    }
}
