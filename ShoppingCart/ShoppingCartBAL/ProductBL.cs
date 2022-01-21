using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDAL;
using ShoppingCartBALObject;


namespace ShoppingCartBAL
{
    public class ProductBL:IProductBl
    {
        private readonly IProductDataAccess _productDataAccess;
        public ProductBL(IProductDataAccess productDataAcess)
        {
            _productDataAccess = productDataAcess;
        }
        public void AddProduct(ProductObject obj)
        {
            _productDataAccess.AddProductDA(obj);
        }

        public IEnumerable<ProductObject> ViewAllProduct(string ProductType, string searchFor)
        {
            return _productDataAccess.ViewAllProductDA(ProductType, searchFor);
        }

        public IEnumerable<CartObject> GetProductFromCart()
        {
            return _productDataAccess.GetProductFromCart();
        }

        public ProductObject ViewProductById(int ProductId)
        {
            return _productDataAccess.ViewProductById(ProductId);
        }

        public void SaveProductInCart(int ProductId)
        {
            _productDataAccess.SaveProductInCart(ProductId);
        }
    }
}
