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
        IEnumerable<ProductReviewObject> ViewProductById(int ProductId);
        void SaveProductInCart(int ProductId, int userId);
        IEnumerable<OrderListObject> GetOrderList(int userId);
        IEnumerable<CartObject> GetProductFromCart(int userId);
        int NoofCartItem(int userId);
        void SaveReviewById(ProductReview review);
        void DeleteFromCart(int UserId, int ProductId);
        void UpdateQuantity(int UserId, int ProductId, int Quantity);
        void CancelOrder(int userId, string orderId);
        void OrderedProducts(int UserId, string orderId);
        void PaymentInfo(OrderInfoObject orderInfo);

    }
}
