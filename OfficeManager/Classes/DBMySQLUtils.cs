using MySql.Data.MySqlClient;

namespace OfficeManager.Classes
{
    public class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password, string charset)
        {
            string connString = "Server=" + host + ";DataBase=" + database + ";port=" + port + ";User ID=" + username + ";Password=" + password + ";CharSet=" + charset;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
