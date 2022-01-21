using Microsoft.AspNetCore.Mvc;
using ShoppingCartBAL;


namespace ShoppingCart.Controllers
{
    public class MyCartController : Controller
    {
        private readonly IProductBl _productBl;
        public MyCartController(IProductBl productBl)
        {
            _productBl = productBl;
        }
        public ActionResult Cart(int ProductId)
        {
            _productBl.SaveProductInCart(ProductId);
            return View("ShowCartProduct");
        }
        public ActionResult ShowCartProduct()
        {
            return View(_productBl.GetProductFromCart());
        }
    }
}
