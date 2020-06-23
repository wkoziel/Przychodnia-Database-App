using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    class Clinic
    {
        public int ID_poradni { get; set; }
        public string Nazwa { get; set; }
        public string Rodzaj_poradni { get; set; }
        public string Opis { get; set; }

        public Clinic(MySqlDataReader dataReader)
        {
            ID_poradni = (int)dataReader["ID_poradni"];
            Nazwa = dataReader["Nazwa"].ToString();
            Rodzaj_poradni = dataReader["Rodzaj_poradni"].ToString();
            Opis = dataReader["Opis"].ToString();
        }
        public override string ToString()
        {
            return $"{ID_poradni} {Nazwa} {Rodzaj_poradni} {Opis}";
        }
    }
}
