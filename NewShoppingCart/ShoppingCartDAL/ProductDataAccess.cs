using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ShoppingCartBALObject;

namespace ShoppingCartDAL
{
    public class ProductDataAccess:IProductDataAccess
    {
        private readonly IProcedureclass _procedureclass;
        public ProductDataAccess(IProcedureclass prcocedureclass)
        {
            _procedureclass = prcocedureclass;
        }
        public void AddProductDA(ProductObject obj)
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", obj.ProductId);
            param.Add("@Brand", obj.Brand);
            param.Add("@RAM", obj.RAM);
            param.Add("@Storage", obj.Storage);
            param.Add("@Model", obj.Model);
            param.Add("@Color", obj.Color);
            param.Add("@Description", obj.Description);
            param.Add("@Price", obj.Price);
            param.Add("@ProductType", obj.ProductType);
            param.Add("@Date", obj.date.ToString());
            _procedureclass.ReturnVoid("AddProduct", param);
        }

        public IEnumerable<ProductObject> ViewAllProductDA(string ProductType, string searchFor)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ProductType", ProductType);
            param.Add("SearchFor", searchFor);
            return _procedureclass.ReturnList<ProductObject>("ViewAllProduct",param);
        }

        public IEnumerable<CartObject> GetProductFromCart(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@userId", userId);
            return _procedureclass.ReturnList<CartObject>("GetProductFromCart",param);
        }

        public void AddUser(LoginObject loginObject)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", loginObject.UserID);
            param.Add("@email", loginObject.email);
            param.Add("@password", loginObject.password);
            param.Add("@IsActive",true);
            if (loginObject.email == "admin@easyshopping.com" && loginObject.password == "shopping_admin")
            {
                param.Add("@Role", "Admin");
            }
            else
            {
                param.Add("@Role", "User");
            }
            param.Add("@LoginProvider", "Custom Login");
            _procedureclass.ReturnVoid("AddUser", param);
        }

        public int AuthenticateUser(LoginObject loginObject)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email, dbType: DbType.String);
            param.Add("@password", loginObject.password, dbType: DbType.String);
            param.Add("@Value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return _procedureclass.CheckUser("CheckUser", param);
        }

        public int GoogleAuthentication(LoginObject loginObject)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email, dbType: DbType.String);
            param.Add("@password", loginObject.password, dbType: DbType.String);
            param.Add("@IsActive", true);
            param.Add("@Role", "User");
            param.Add("@LoginProvider", "Google Login");
            param.Add("@Value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return _procedureclass.CheckUser("GoogleAuthentication", param);

        }

        public string GetRole(LoginObject loginObject)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email, dbType: DbType.String);
            param.Add("@password", loginObject.password, dbType: DbType.String);
            //param.Add("@Role", dbType: DbType.String, direction: ParameterDirection.ReturnValue);
            return _procedureclass.GetRoleFromDB("GetRole", param);
        }

        public IEnumerable<ProductReviewObject> ViewProductById(int ProductId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            return _procedureclass.ReturnList<ProductReviewObject>("ViewProductById", param);
        }

        public void SaveProductInCart(int ProductId, int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            param.Add("@UserId", userId);
            _procedureclass.ReturnVoid("SaveProductInCart", param);
        }

        public int NoofCartItem(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@Value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return _procedureclass.CheckUser("NoofCartItem",param);
        }

        public void SaveReviewById(ProductReview review)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", review.UserId);
            param.Add("@ProductId", review.ProductId);
            param.Add("@ReviewText", review.ReviewText);
            _procedureclass.ReturnVoid("SaveReviewById", param);
        }

        public void DeleteFromCart(int UserId, int ProductId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UserId);
            param.Add("@ProductId", ProductId);
            _procedureclass.ReturnVoid("DeleteFromCart", param);
        }

        public void UpdateQuantity(int UserId, int ProductId, int Quantity)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UserId);
            param.Add("@ProductId", ProductId);
            param.Add("@Quantity", Quantity);
            _procedureclass.ReturnVoid("UpdateQuantity",param);
        }
        public void OrderedProducts(int UserId, string orderId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UserId);
            param.Add("@OrderId", orderId);
            _procedureclass.ReturnVoid("OrderedProducts", param);
        }

        public void PaymentInfo(OrderInfoObject orderInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderId", orderInfo.OrderId);
            param.Add("@UserId", orderInfo.UserId);
            param.Add("@Amount", orderInfo.Amount);
            param.Add("@Method", orderInfo.Method);
            param.Add("@Email", orderInfo.Email);
            param.Add("@Contact", orderInfo.Contact);
            param.Add("@BankTransactionID", orderInfo.BankTransactionID);
            param.Add("@Address", orderInfo.Address);
            _procedureclass.ReturnVoid("PaymentInfo", param);

        }

        public IEnumerable<OrderListObject> GetOrderList(int userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", userId);
            return _procedureclass.ReturnList<OrderListObject>("GetOrderList", param);
        }

        public void CancelOrder(int userId, string orderId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@OrderId", orderId);
            _procedureclass.ReturnVoid("CancelOrder", param);
        }

    }
}
