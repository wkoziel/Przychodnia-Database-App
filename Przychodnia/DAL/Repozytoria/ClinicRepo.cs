using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class ClinicRepo
    {
        private const string ALL_CLINICS_QUERY = "SELECT * FROM poradnia";
        public static List<Clinic> GetAllClinics()
        {
            List<Clinic> clinics = new List<Clinic>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_CLINICS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        clinics.Add(new Clinic(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            foreach (var item in clinics)
            {
                Debug.WriteLine(item.ToString());
            }

            return clinics;
        }
    }
}
