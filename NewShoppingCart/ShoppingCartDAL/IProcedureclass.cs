using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ShoppingCartBALObject;
namespace ShoppingCartDAL
{
    public interface IProcedureclass
    {
        void ReturnVoid(string procedureName, DynamicParameters param = null);
        IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);
        int CheckUser(string procedureName, DynamicParameters param = null);
        string GetRoleFromDB(string procedureName, DynamicParameters param = null);
        //IEnumerable<ProductReviewObject> ViewProductById(string procedureName, DynamicParameters param = null);
        //void SaveProductInCart(string procedureName, DynamicParameters param = null);
        //IEnumerable<T> ReturnListFromCart<T>(string procedureName, DynamicParameters param = null);
        //int NoofCartItem(string procedureName, DynamicParameters param = null);
        /*void SaveReviewById(string procedureName, DynamicParameters param = null);
        void DeleteFromCart(string procedureName, DynamicParameters param = null);
        void UpdateQuantity(string procedureName, DynamicParameters param = null);
        void OrderedProducts(string procedureName, DynamicParameters param = null);
        void PaymentInfo(string procedureName, DynamicParameters param = null);*/
        //IEnumerable<OrderListObject> GetOrderList(string procedureName, DynamicParameters param=null);
    }
}
