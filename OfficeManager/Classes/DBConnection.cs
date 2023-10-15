using MySql.Data.MySqlClient;


namespace OfficeManager.Classes
{
    internal class DBConnection
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "employees";
            string username = "root";
            string password = "98053076";
            string charset = "utf8mb4";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password, charset);
        }
    }
}
