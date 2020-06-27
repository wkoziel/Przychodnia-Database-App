using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class DoctorRepo
    {
        private const string ALL_DOCTORS_QUERY = "SELECT * FROM lekarz";
        public static List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_DOCTORS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        doctors.Add(new Doctor(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            foreach (var item in doctors)
            {
                Debug.WriteLine(item.ToString());
            }

            return doctors;
        }
    }
}
