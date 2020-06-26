using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class RoomRepo
    {
        private const string ALL_ROOMS_QUERY = "SELECT * FROM sala";
        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_ROOMS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        rooms.Add(new Room(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            foreach (var item in rooms)
            {
                Debug.WriteLine(item.ToString());
            }

            return rooms;
        }
    }
}
