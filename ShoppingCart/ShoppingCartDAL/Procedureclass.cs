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
        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
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

        [Obsolete]
        public IEnumerable<T> ReturnListFromCart<T>(string procedureName)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedureName, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        [Obsolete]
        public bool CheckUser(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure); 
                int rowCount = param.Get<int>("@Exists");
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        [Obsolete]
        public string GetRoleFromDB(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                string Role = param.Get<string>("@Role");
                return Role;
            }
        }
        [Obsolete]
        public ProductObject ViewProductById(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(str))
            {
                sqlcon.Open();
                return (ProductObject)sqlcon.Query(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

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
        }
    }
}
