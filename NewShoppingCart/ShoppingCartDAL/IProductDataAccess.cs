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
        int AuthenticateUser(LoginObject loginObject);
        string GetRole(LoginObject loginObject);
        IEnumerable<ProductReviewObject> ViewProductById(int ProductId);
        void SaveProductInCart(int ProductId, int userId);
        IEnumerable<CartObject> GetProductFromCart(int userId);
        int NoofCartItem(int userId);
        void SaveReviewById(ProductReview review);
        void DeleteFromCart(int UserId, int ProductId);
        void UpdateQuantity(int UserId, int ProductId, int Quantity);
        void OrderedProducts(int UserId, string orderId);
        void PaymentInfo(OrderInfoObject orderInfo);
        int GoogleAuthentication(LoginObject loginObject);
        IEnumerable<OrderListObject> GetOrderList(int userId);
        void CancelOrder(int userId, string orderId);
    }
}
