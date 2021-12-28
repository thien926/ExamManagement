using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class LevelDAO
    {
        private static LevelDAO instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static LevelDAO Instance { get => (instance == null) ? (instance = new LevelDAO()) : instance; private set => instance = value; }

        private LevelDAO() { }

        public DataTable GetAll() {
            var sql = "SELECT [Id], name AS [Tên trình độ] FROM [Levels]";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public string[] getAllForRegister()
        {
            string query = "select [Id], [name] from Levels";

            List<string> data = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Đọc từng dòng tập kết quả
                    while (reader.Read())
                    {
                        data.Add(reader.GetInt32(0) + "-" + reader.GetString(1));
                    }
                }

                connection.Close();
            }

            return data.ToArray<string>();
        }
    }
}
