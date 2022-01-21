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
            _procedureclass.ExecuteWithoutReturn("AddProduct", param);
        }

        public IEnumerable<ProductObject> ViewAllProductDA(string ProductType, string searchFor)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ProductType", ProductType);
            param.Add("SearchFor", searchFor);
            return _procedureclass.ReturnList<ProductObject>("ViewAllProduct",param);
        }

        public IEnumerable<CartObject> GetProductFromCart()
        {
            return _procedureclass.ReturnListFromCart<CartObject>("GetProductFromCart");
        }

        public void AddUser(LoginObject loginObject)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email);
            param.Add("@password", loginObject.password);
            param.Add("@IsActive",false);
            if (loginObject.email == "admin@easyshopping.com" && loginObject.password == "shopping_admin")
            {
                param.Add("@Role", "Admin");
            }
            else
            {
                param.Add("@Role", "User");
            }
            _procedureclass.ExecuteWithoutReturn("AddUser", param);
        }

        public bool AuthenticateUser(LoginObject loginObject)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email, dbType: DbType.String);
            param.Add("@password", loginObject.password, dbType: DbType.String);
            param.Add("@Exists", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return _procedureclass.CheckUser("CheckUser", param);
        }

        public string GetRole(LoginObject loginObject)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@email", loginObject.email, dbType: DbType.String);
            param.Add("@password", loginObject.password, dbType: DbType.String);
            param.Add("@Role", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return _procedureclass.GetRoleFromDB("GetRole", param);
        }

        public ProductObject ViewProductById(int ProductId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            return _procedureclass.ViewProductById("ViewProductById", param);
        }

        public void SaveProductInCart(int ProductId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            _procedureclass.SaveProductInCart("SaveProductInCart", param);
        }
    }
}
