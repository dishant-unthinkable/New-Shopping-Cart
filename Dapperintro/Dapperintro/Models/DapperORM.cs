using Dapper;
using Microsoft.Data.SqlClient;
namespace Dapperintro.Models
{
    public static class DapperORM
    {
        //private static string connectionString = @"Data Source=(local)\sqle2012;Initial Catalog=DapperDB;Integrated Security=True;";
        private static string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DapperIntro;TrustServerCertificate=True;Data Source=DESKTOP-TQUUC0F";
        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                return (T)Convert.ChangeType(sqlcon.ExecuteScalar(procedureName, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
           
            }
        }

    }
}
