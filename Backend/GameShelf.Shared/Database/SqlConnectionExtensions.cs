using Microsoft.Data.SqlClient;

namespace ProjectManagement.Shared.Database
{
    public static class SqlConnectionExtensions
    {
        public static SqlConnection CreateOpenConnection(this string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}