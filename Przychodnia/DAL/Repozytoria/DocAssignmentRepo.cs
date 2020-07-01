using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class DocAssignmentRepo
    {
        //Pobiera przydział lekarzy z bazy
        public static List<DocAssignment> GetAllDocAssignments()
        {
            List<DocAssignment> docassigments = new List<DocAssignment>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM przydział_lekarzy", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        docassigments.Add(new DocAssignment(dataReader));
                    connection.Close();
                }
            }
            catch { }
            return docassigments;
        }
    }
}
