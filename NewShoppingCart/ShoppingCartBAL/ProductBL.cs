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

        public IEnumerable<CartObject> GetProductFromCart(int userId)
        {
            return _productDataAccess.GetProductFromCart(userId);
        }

        public IEnumerable<ProductReviewObject> ViewProductById(int ProductId)
        {
            return _productDataAccess.ViewProductById(ProductId);
        }

        public void SaveProductInCart(int ProductId, int userId)
        {
            _productDataAccess.SaveProductInCart(ProductId, userId);
        }

        public int NoofCartItem(int userId)
        {
            return _productDataAccess.NoofCartItem(userId);
        }

        public void SaveReviewById(ProductReview review)
        {
            _productDataAccess.SaveReviewById(review);
        }

        public void DeleteFromCart(int UserId, int ProductId)
        {
            _productDataAccess.DeleteFromCart(UserId, ProductId);
        }

        public void UpdateQuantity(int UserId, int ProductId, int Quantity)
        {
            _productDataAccess.UpdateQuantity(UserId, ProductId, Quantity);
        }

        public void OrderedProducts(int UserId, string orderId)
        {
            _productDataAccess.OrderedProducts(UserId, orderId);
        }

        public void PaymentInfo(OrderInfoObject orderInfo)
        {
            _productDataAccess.PaymentInfo(orderInfo);
        }

        public IEnumerable<OrderListObject> GetOrderList(int userId)
        {
            return _productDataAccess.GetOrderList(userId);
        }

        public void CancelOrder(int userId, string orderId)
        {
            _productDataAccess.CancelOrder(userId, orderId);
        }
    }
}
