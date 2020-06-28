using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    class Appointment
    {
        public int ID_wizyty { get; set; }
        public string PESEL { get; set; }
        public int ID_lekarza { get; set; }
        public int Numer_sali { get; set; }
        public string Rodzaj_wizyty { get; set; }
        public string Opis_dolegliwosci { get; set; }
        public string Data_wizyty { get; set; }
        public string Godzina_wizyty { get; set; }
        public string Choroba { get; set; }
        public string Leczenie { get; set; }
        public string Zwolnienie { get; set; }

        public Appointment(MySqlDataReader dataReader)
        {
            ID_wizyty = (int)dataReader["ID_wizyty"];
            PESEL = dataReader["PESEL"].ToString();
            ID_lekarza = (int)dataReader["ID_lekarza"];
            Numer_sali = (int)dataReader["Numer_sali"];
            Rodzaj_wizyty = dataReader["Rodzaj_wizyty"].ToString();
            Opis_dolegliwosci = dataReader["Opis_dolegliwości"].ToString();
            Data_wizyty = dataReader["Data_wizyty"].ToString().Remove(10);
            Godzina_wizyty = dataReader["Godzina_wizyty"].ToString();
            Choroba = dataReader["Choroba"].ToString();
            Leczenie = dataReader["Leczenie"].ToString();
            Zwolnienie = dataReader["Zwolnienie"].ToString();
        }

        public override string ToString()
        {
            return $"{ID_wizyty} {PESEL} {ID_lekarza} {Numer_sali} {Rodzaj_wizyty} {Opis_dolegliwosci} {Data_wizyty} {Godzina_wizyty} {Choroba} {Leczenie} {Zwolnienie}";
        }
    }
}
