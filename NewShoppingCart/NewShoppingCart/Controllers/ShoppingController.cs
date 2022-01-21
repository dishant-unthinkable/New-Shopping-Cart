using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewShoppingCart.Models;
using ShoppingCartBAL;
using ShoppingCartBALObject;

namespace NewShoppingCart.Controllers
{
    public class ShoppingController : Controller
    {
        //public string _productType;
        private readonly IProductBl _productBl;
        private readonly IProductObject _productObject;
        public ShoppingController(IProductBl productBl, IProductObject productObject)
        {
            _productBl = productBl;
            _productObject = productObject;
        }
        
        public ActionResult Index()
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            TempData.Keep("cartItems");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            else if(TempData["userId"] != (object)4)
            {
                ViewBag.Message = "You are not Authorised to View this Page.";
                return View("/Views/Home/Error.cshtml");
            }
               
            return View();
        }
        [HttpPost]
        public ActionResult AddAllProducts(ProductObject obj)
        {
            TempData.Keep("usermail");
            TempData.Keep("userId");
            TempData.Keep("cartItems");
            //ProductObject obj2 = new ProductObject();
            DateTime dateTime = DateTime.UtcNow.Date;
            _productObject.ProductId = obj.ProductId;
            _productObject.Brand = obj.Brand;
            _productObject.RAM = obj.RAM;
            _productObject.Storage = obj.Storage;
            _productObject.Model = obj.Model;
            _productObject.Color = obj.Color;
            _productObject.Description = obj.Description;
            _productObject.Price = obj.Price;
            _productObject.ProductType = obj.ProductType;
            _productObject.date = dateTime;
            _productBl.AddProduct((ProductObject)_productObject);
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            else if (TempData["userId"] != (object)4)
            {
                ViewBag.Message = "You are not Authorised to View this Page.";
                return View("/Views/Home/Error.cshtml");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ProductList(string ProductType, string? searchFor =null)
        {
            TempData.Keep("userId");
            TempData.Keep("usermail");
            TempData.Keep("cartItems");
            if (TempData["usermail"] == null)
                return RedirectToAction("Login", "Account");
            //_productType = ProductType;
            ViewBag.ProductType = ProductType;
            return View(_productBl.ViewAllProduct(ProductType, searchFor));
        }
        
    }
}
