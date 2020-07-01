using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Przychodnia.DAL.Encje
{

    class Patient
    {
        public string PESEL { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Plec { get; set; }
        public string Data_urodzenia { get; set; }
        public int Wiek { get; set; }
        public string Adres { get; set; }
        public string Numer_kontaktowy { get; set; }

        public Patient(MySqlDataReader dataReader)
        {
            PESEL = dataReader["PESEL"].ToString();
            Imie = dataReader["Imię"].ToString();
            Nazwisko = dataReader["Nazwisko"].ToString();
            Plec = dataReader["Płeć"].ToString();
            Data_urodzenia = dataReader["Data_urodzenia"].ToString().Remove(10);
            Wiek = (int)dataReader["Wiek"];
            Adres = dataReader["Adres"].ToString();
            Numer_kontaktowy = dataReader["Numer_kontaktowy"].ToString();
        }

        public override string ToString()
        {
            return $"{PESEL} {Imie} {Nazwisko} {Plec} {Data_urodzenia} {Wiek} {Adres} {Numer_kontaktowy}";
        }
    }
}
