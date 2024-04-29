using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCDotNetCore.ConsoleApp
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-SO9GMR6", //Server Name
            InitialCatalog = "DotnetTrainingBatch4", //DB Name
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
      
    }
}
