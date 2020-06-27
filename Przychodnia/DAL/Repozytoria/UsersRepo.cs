using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class UsersRepo
    {
        private const string ALL_USERS_QUERY = "SELECT * FROM użytkownicy";
        public static List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_USERS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        users.Add(new Users(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            //foreach (var item in users)
            //{
            //    Debug.WriteLine(item.ToString());
            //}
            return users;
        }
    }
}
