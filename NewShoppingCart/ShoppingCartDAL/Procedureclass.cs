using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using ShoppingCartBALObject;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ShoppingCartDAL
{
    public class Procedureclass : IProcedureclass
    {
        //static readonly string str = Properties.Settings.Default.ShoppingCartConnectionString;
        readonly string str;
        public Procedureclass()
        {
            var configuration = GetConfiguration();
            str = configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }
        
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange:true);
            return builder.Build();
        }
        [Obsolete]
        public void ReturnVoid(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        [Obsolete]
        public IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
           
            }
        }

        /*[Obsolete]
        public IEnumerable<T> ReturnListFromCart<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }*/

        [Obsolete]
        public int CheckUser(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure); 
                return param.Get<int>("@Value");
                //return userId;
            }
        }

        [Obsolete]
        public string GetRoleFromDB(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                string Role = sqlcon.QueryFirstOrDefault<string>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                //string Role = param.Get<string>("@Role");
                return Role;
            }
        }
        /*[Obsolete]
        public IEnumerable<ProductReviewObject> ViewProductById(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return sqlcon.Query<ProductReviewObject>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
        [Obsolete]
        public void SaveProductInCart(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }*/

        /*public int NoofCartItem(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                int Count = param.Get<int>("@Count");
                return Count;
            }
        }*/

        /*public void SaveReviewById(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteFromCart(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateQuantity(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void OrderedProducts(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void PaymentInfo(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }*/

        /*public IEnumerable<OrderListObject> GetOrderList(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return sqlcon.Query<OrderListObject>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }*/
    }
}
