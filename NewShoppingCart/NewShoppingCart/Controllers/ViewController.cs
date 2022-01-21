using Microsoft.AspNetCore.Mvc;
using ShoppingCartBALObject;
using ShoppingCartBAL;

namespace NewShoppingCart.Controllers
{
    public class ViewController : Controller
    {
        private readonly IProductBl _productBl;
        //private readonly IProductObject _productObject;
        public ViewController(IProductBl productBl)
        {
            _productBl = productBl;
            
        }
        public ActionResult ViewProduct(int ProductId)
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            TempData.Keep("cartItems");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            IEnumerable<ProductReviewObject> product = _productBl.ViewProductById(ProductId);
            return View(product);
           
        }
        //[HttpPost]
        public ActionResult SaveReview(int UserId, int ProductId, string Feedback)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            ProductReview productReview = new ProductReview();
            productReview.UserId = UserId;
            productReview.ProductId = ProductId;
            productReview.ReviewText = Feedback;
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            _productBl.SaveReviewById(productReview);
            return RedirectToAction("ViewProduct", "View", new {ProductId = ProductId });
        }
    }
}
