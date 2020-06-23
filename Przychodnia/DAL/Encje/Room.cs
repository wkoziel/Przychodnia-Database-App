using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    class Room
    {
        public int Numer_sali { get; set; }
        public int ID_poradni { get; set; }
        public string Typ_sali { get; set; }

        public Room(MySqlDataReader dataReader)
        {
            Numer_sali = (int)dataReader["Numer_sali"];
            ID_poradni = (int)dataReader["ID_poradni"];
            Typ_sali = dataReader["Typ_sali"].ToString();
        }

        public override string ToString()
        {
            return $"{Numer_sali} {ID_poradni} {Typ_sali}";
        }
    }
}
