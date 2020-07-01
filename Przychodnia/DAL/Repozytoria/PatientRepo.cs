using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class PatientRepo
    {
        public static List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM pacjent", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        patients.Add(new Patient(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return patients;
        }

        public static void AddNewPatient(string pesel, string imie, string nazwisko, string plec, string rok, string miesiac, string dzien, string wiek, string adres, string numer)
        {
            if (int.Parse(miesiac) < 10)
                miesiac = "0" + miesiac;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO pacjent VALUES('{pesel}','{imie}','{nazwisko}','{plec}','{rok}-{miesiac}-{dzien}','{wiek}','{adres}','{numer}');", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        public static void UpdatePatient(string pesel, string imie, string nazwisko, string plec, string rok, string miesiac, string dzien, string wiek, string adres, string numer)
        {
            if (int.Parse(miesiac) < 10)
                miesiac = "0" + miesiac;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"UPDATE pacjent SET PESEL = '{pesel}', Imię = '{imie}', Nazwisko = '{nazwisko}', Płeć = '{plec}', Data_urodzenia = '{rok}-{miesiac}-{dzien}', Wiek = '{wiek}', Adres = '{adres}', Numer_kontaktowy = '{numer}' WHERE PESEL = {pesel}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        public static void DeletePatient(string pesel)
        {
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"DELETE FROM pacjent WHERE PESEL = {pesel}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }
    }
}
