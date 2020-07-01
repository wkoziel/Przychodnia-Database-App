using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class AppointmentRepo
    {
        //Pobiera wszystkie wizyty z bazy
        public static List<Appointment> GetAllAppoitments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM wizyta", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        appointments.Add(new Appointment(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return appointments;
        }

        //Dodaje nową wizytę do bazy
        public static void AddNewAppointment(string idwizyty, string pesel, string idlekarza, string nrsali, string rodzaj, string dolegliwosci, string data, string godzina, string choroba, string leczenie, string zwolnienie)
        {
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"INSERT INTO wizyta VALUES('{idwizyty}','{pesel}','{idlekarza}','{nrsali}','{rodzaj}','{dolegliwosci}','{data.Substring(6,4)}-{data.Substring(3,2)}-{data.Substring(0,2)}','{godzina}','{choroba}','{leczenie}','{zwolnienie}');", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        //Uaktualnie wizytę w bazie
        public static void EditAppointment(string idwizyty, string pesel, string idlekarza, string nrsali, string rodzaj, string dolegliwosci, string data, string godzina, string choroba, string leczenie, string zwolnienie)
        {
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"UPDATE wizyta SET ID_wizyty = '{idwizyty}', PESEL = '{pesel}', ID_lekarza = '{idlekarza}', Numer_sali = '{nrsali}', Rodzaj_wizyty = '{rodzaj}', Opis_dolegliwości = '{dolegliwosci}', Data_wizyty = '{data.Substring(6, 4)}-{data.Substring(3, 2)}-{data.Substring(0, 2)}', Godzina_wizyty = '{godzina}', Choroba = '{choroba}', Leczenie = '{leczenie}', Zwolnienie = '{zwolnienie}' WHERE ID_wizyty = {idwizyty}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }

        //Usuwa wizytę z bazy
        public static void DeleteAppointment(string idwizyty)
        {
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand($"DELETE FROM wizyta WHERE ID_wizyty = {idwizyty}", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch { }
        }
    }
}
