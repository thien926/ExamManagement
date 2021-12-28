using System.Collections;
using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class ExaminationDAO
    {
        private static ExaminationDAO instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static ExaminationDAO Instance { get => (instance == null) ? (instance = new ExaminationDAO()) : instance; private set => instance = value; }

        private ExaminationDAO() { }

        public DataTable GetAll() {
            var sql = "select [Id], name as [Tên khóa thi], examDate as [Ngày thi] from Examinations";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public Boolean AddExamination(ExaminationDTO data)
        {
            string query = string.Format("INSERT INTO [dbo].[Examinations] ([name] ,[examDate]) VALUES (N'{0}', '{1}')", data.name, data.examDate);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateExamination(ExaminationDTO data)
        {
            string query = string.Format("UPDATE [dbo].[Examinations] SET [name] = N'{0}' , [examDate] = '{1}' WHERE " +
                "[Id] = {2} ", data.name, data.examDate, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean DeleteExamination(int Id)
        {
            string query = string.Format("DELETE FROM [dbo].[Examinations] WHERE [Id] = {0} ", Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public string[] getAllForRegister()
        {
            string query = "select [Id], [name] from Examinations";

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
