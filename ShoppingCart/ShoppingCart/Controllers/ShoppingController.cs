using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCartBAL;
using ShoppingCartBALObject;

namespace ShoppingCart.Controllers
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
            
            return View();
        }
        [HttpPost]
        public ActionResult AddAllProducts(ProductObject obj)
        {
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
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ProductList(string ProductType="Laptop", string searchFor=null)
        {
            //_productType = ProductType;
            ViewBag.ProductType = ProductType;
            return View(_productBl.ViewAllProduct(ProductType, searchFor));
        }
        
    }
}
