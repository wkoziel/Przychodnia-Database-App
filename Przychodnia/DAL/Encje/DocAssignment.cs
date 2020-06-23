using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    class DocAssignment
    {
        public int ID_lekarza { get; set; }
        public int ID_poradni { get; set; }

        public DocAssignment(MySqlDataReader dataReader)
        {
            ID_lekarza = (int)dataReader["ID_lekarza"];
            ID_poradni = (int)dataReader["ID_poradni"];
        }

        public override string ToString()
        {
            return $"{ID_lekarza} {ID_poradni}";
        }
    }
}
