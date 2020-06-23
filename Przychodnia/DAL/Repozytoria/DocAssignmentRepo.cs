using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Przychodnia.DAL.Encje;
using System.Diagnostics;

namespace Przychodnia.DAL.Repozytoria
{
    class DocAssignmentRepo
    {
        private const string ALL_DOCASSIGMENTS_QUERY = "SELECT * FROM przydział_lekarzy";
        public static List<DocAssignment> GetAllDocAssignments()
        {
            List<DocAssignment> docassigments = new List<DocAssignment>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    DBConnection.Instance.printBuilder();
                    MySqlCommand command = new MySqlCommand(ALL_DOCASSIGMENTS_QUERY, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        docassigments.Add(new DocAssignment(dataReader));
                    connection.Close();
                }
            }
            catch { }

            //Console print
            foreach (var item in docassigments)
            {
                Debug.WriteLine(item.ToString());
            }

            return docassigments;
        }
    }
}
