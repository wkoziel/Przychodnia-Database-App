using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class PatientRepo
    {
        private const string ALL_PATIENTS_QUERY = "SELECT * FROM pacjent";
        public static List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_PATIENTS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        patients.Add(new Patient(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            foreach (var item in patients)
            {
                Debug.WriteLine(item.ToString());
            }

            return patients;
        }
    }
}
