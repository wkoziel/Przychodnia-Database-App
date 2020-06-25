using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class AppointmentRepo
    {
        private const string ALL_APPOINTMENTS_QUERY = "SELECT * FROM wizyta";
        public static List<Appointment> GetAllAppoitments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_APPOINTMENTS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        appointments.Add(new Appointment(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            //foreach (var item in appointments)
            //{
            //    Debug.WriteLine(item.ToString());
            //}

            return appointments;
        }
    }
}
