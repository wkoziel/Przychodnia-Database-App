using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Przychodnia.DAL
{
    class DBConnection
    {
        private static MySqlConnectionStringBuilder stringBuilder;
        private static string Nickname { get; set; } = "root";
        private static string Password { get; set; } = "";
        
        public static DBConnection Instance
        {
            get => new DBConnection();
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {
            stringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = Nickname,
                Password = Password,
                Server = "localhost",
                Database = "przychodnia",
                Port = 3306
            };
        }

        public static void Login(string user, string password)
        {

            Nickname = user; Password = password;
        }

        public void printBuilder() => Debug.Write("\n"+stringBuilder.ToString());
    }
}
