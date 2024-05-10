using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            string json = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //Json to C#


            return lst;

        }

        public T FindById<T>(string query, params AdoDotnetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                // foreach (var item in parameters)
                // {
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}
                cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());

            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            if(dt.Rows.Count == 0)
            {
                return default;

            }
            string json = JsonConvert.SerializeObject(dt); // C# to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!;  //Json to C#


            return lst[0];


        }

        public int Execute(string query, params AdoDotnetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());
            }

            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;

        }

    }
    public class AdoDotnetParameter
    {
        public AdoDotnetParameter() { }
        public AdoDotnetParameter(string name, object value)
        {
            Name = name;
            Value = value;

        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
