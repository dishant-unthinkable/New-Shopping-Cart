using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartBALObject;

namespace ShoppingCartBAL
{
    public interface IProductBl
    {
        void AddProduct(ProductObject obj);
        IEnumerable<ProductObject> ViewAllProduct(string ProductTyp, string searchFor);
        ProductObject ViewProductById(int ProductId);
        void SaveProductInCart(int ProductId);
        IEnumerable<CartObject> GetProductFromCart();
    }
}
