using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    public class Doctor
    {
        public int ID_lekarza { get; set; }
        public int ID_poradni { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Numer_telefonu { get; set; }
        public string Specjalizacja { get; set; }

        public Doctor(MySqlDataReader dataReader)
        {
            ID_lekarza = (int)dataReader["ID_lekarza"];
            ID_poradni = (int)dataReader["ID_poradni"];
            Imie = dataReader["Imię"].ToString();
            Nazwisko = dataReader["Nazwisko"].ToString();
            Numer_telefonu = dataReader["Numer_telefonu"].ToString();
            Specjalizacja = dataReader["Specjalizacja"].ToString();
        }

        public override string ToString()
        {
            return $"{ID_lekarza} {ID_poradni} {Imie} {Nazwisko} {Numer_telefonu} {Specjalizacja}";
        }
    }
}
