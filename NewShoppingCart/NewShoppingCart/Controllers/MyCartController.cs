using Microsoft.AspNetCore.Mvc;
using ShoppingCartBAL;
using ShoppingCartBALObject;


namespace NewShoppingCart.Controllers
{
    public class MyCartController : Controller
    {
        private readonly IProductBl _productBl;
        public IAccountController _accountController;
        public MyCartController(IProductBl productBl, IAccountController accountController)
        {
            _productBl = productBl;
            _accountController = accountController;
        }
        public ActionResult Cart(int ProductId)
        {
            TempData.Keep("usermail");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
#pragma warning disable CS8605 // Unboxing a possibly null value.
            int userId = (int)TempData["userId"];
#pragma warning restore CS8605 // Unboxing a possibly null value.
            TempData.Keep("userId");
            TempData.Keep("cartItems");
            if (userId != 0)
            {
                
                _productBl.SaveProductInCart(ProductId, userId);
                return RedirectToAction("ShowCartProduct");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult ShowCartProduct()
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
#pragma warning disable CS8605 // Unboxing a possibly null value.
            int userId = (int)TempData["userId"];
#pragma warning restore CS8605 // Unboxing a possibly null value.
            TempData.Keep("userId");
            TempData.Keep("cartItems");
            if (userId != 0)
            {
                TempData["cartItems"] = _productBl.NoofCartItem(userId);
                return View(_productBl.GetProductFromCart(userId));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        public ActionResult DeleteFromCart(int UserId,int ProductId)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            _productBl.DeleteFromCart(UserId,ProductId);
            TempData["cartItems"] = _productBl.NoofCartItem(UserId);
            return RedirectToAction("ShowCartProduct");
        }
        
        public ActionResult UpdateQuantity(IFormCollection form)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            int UserId = Convert.ToInt32(form["UserId"]);
            int ProductId = Convert.ToInt32(form["ProductId"]);
            int Quantity = Convert.ToInt32(form["Quantity"]);

            _productBl.UpdateQuantity(UserId, ProductId, Quantity);
            return RedirectToAction("ShowCartProduct");
            
        }
    }
}
