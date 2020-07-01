using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class UsersRepo
    {
        //Pobiera wszystkich użytkowników z bazy
        public static List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM użytkownicy", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        users.Add(new Users(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return users;
        }
    }
}
