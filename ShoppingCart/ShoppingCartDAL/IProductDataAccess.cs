using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBALObject;

namespace ShoppingCartDAL
{
    public interface IProductDataAccess
    {
        void AddProductDA(ProductObject obj);
        IEnumerable<ProductObject> ViewAllProductDA(string ProductType, string searchFor);
        void AddUser(LoginObject loginObject);
        bool AuthenticateUser(LoginObject loginObject);
        string GetRole(LoginObject loginObject);
        ProductObject ViewProductById(int ProductId);
        void SaveProductInCart(int ProductId);
        IEnumerable<CartObject> GetProductFromCart();
    }
}
