using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class RoomRepo
    {
        //Pobiera wszystkie sale z bazy
        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM sala", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        rooms.Add(new Room(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return rooms;
        }
    }
}
