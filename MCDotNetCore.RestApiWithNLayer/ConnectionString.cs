
namespace MCDotNetCore.RestApiWithNLayer
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
