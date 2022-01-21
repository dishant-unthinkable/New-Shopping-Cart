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
        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);
        IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null);
        bool CheckUser(string procedureName, DynamicParameters param = null);
        string GetRoleFromDB(string procedureName, DynamicParameters param = null);
        ProductObject ViewProductById(string procedureName, DynamicParameters param = null);
        void SaveProductInCart(string procedureName, DynamicParameters param = null);
        IEnumerable<T> ReturnListFromCart<T>(string procedureName);
    }
}
