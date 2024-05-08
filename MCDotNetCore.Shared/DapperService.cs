using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MCDotNetCore.Shared
{
    public class DapperService

    {

        private readonly string _connectionstring;

        public DapperService(string connectionstring)
        {
            _connectionstring = connectionstring;

        }

        public List<T> Query<T>(string query, object? param = null)
        {
            //if(param != null)
            //{
            //    var lst = db.Query<T>(query, param).ToList();
          //  }
           // else
           // {
            //    var lst = db.Query<T>(query, param).ToList();
           // }
            using IDbConnection db = new SqlConnection(_connectionstring);
            var lst = db.Query<T>(query,param).ToList();
            return lst;

        }

        public T FindById<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionstring);
            var item = db.Query<T>(query, param).FirstOrDefault();
            return item!;

        }

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionstring);
            var result = db.Execute(query, param);
            return result;

        }
    }
}
