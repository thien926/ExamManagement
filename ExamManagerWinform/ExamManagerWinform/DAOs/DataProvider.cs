using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class DataProvider
    {
        private static DataProvider instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";

        internal static DataProvider Instance { get => (instance == null) ? (instance = new DataProvider()):instance; private set => instance = value; }

        private DataProvider() { }

        public DataTable ExcuteQuery(string query) {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }
    }
}
