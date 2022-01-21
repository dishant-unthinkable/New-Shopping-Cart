using Microsoft.AspNetCore.Mvc;
using ShoppingCartBALObject;
using ShoppingCartBAL;

namespace ShoppingCart.Controllers
{
    public class ViewController : Controller
    {
        private readonly IProductBl _productBl;
        public ViewController(IProductBl productBl)
        {
            _productBl = productBl;
        }
        public ActionResult ViewProduct(int ProductId)
        {
            ProductObject product = _productBl.ViewProductById(ProductId);
            return View(product);
           
        }
    }
}
