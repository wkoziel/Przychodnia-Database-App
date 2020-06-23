using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{
    class Users
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string ID { get; set; }
        public Users(MySqlDataReader dataReader)
        {
            Login = dataReader["Login"].ToString();
            Haslo = dataReader["Hasło"].ToString();
            ID = dataReader["CzyLekarz"].ToString() == "" ? "0" : dataReader["CzyLekarz"].ToString();
        }

        public override string ToString()
        {
            return $"{Login} {Haslo} {ID}";
        }
    }
}
