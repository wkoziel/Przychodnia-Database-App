using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class ClinicRepo
    {
        //Pobiera wszystkie poradnie z bazy
        public static List<Clinic> GetAllClinics()
        {
            List<Clinic> clinics = new List<Clinic>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM poradnia", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        clinics.Add(new Clinic(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return clinics;
        }
    }
}
