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
    class StudentDAO
    {
        private static StudentDAO instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static StudentDAO Instance { get => (instance == null) ? (instance = new StudentDAO()) : instance; private set => instance = value; }

        private StudentDAO() { }

        public DataTable GetAll() {
            var sql = "select [Id], name as [Tên thí sinh], gender as [Giới tính], phone as [Số điện thoại], bornDate as [Ngày sinh]" +
                ", citizenCard as [CCCD], issueDate as [Ngày cấp], issuePlace as [Nơi cấp], email as [Mail] from Students";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public Boolean AddStudent(StudentDTO data)
        {
            string query = string.Format("INSERT INTO [dbo].[Students] ([name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email])" +
                " VALUES (N'{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}', '{6}', '{7}')", data.name, data.gender, data.bornDate, data.citizenCard,
                data.issueDate, data.issuePlace, data.phone, data.email);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateStudent(StudentDTO data)
        {
            string query = string.Format("UPDATE [dbo].[Students] SET [name] = N'{0}', [gender] = N'{1}', [bornDate] = '{2}', [citizenCard] = '{3}', [issueDate] = '{4}', [issuePlace] = N'{5}', [phone] = '{6}', [email] = '{7}' WHERE [Id] = '{8}'", data.name, data.gender, data.bornDate, data.citizenCard, data.issueDate, data.issuePlace, data.phone, data.email, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean DeleteStudent(int Id)
        {
            string query = string.Format("DELETE FROM [dbo].[Students] WHERE [Id] = {0} ", Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public StudentDTO getStudent(int Id)
        {
            string query = string.Format("SELECT [Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email] FROM [dbo].[Students] WHERE [Id] = {0} ", Id);

            StudentDTO data = null;

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data = new StudentDTO();
                    // Đọc từng dòng tập kết quả
                    while (reader.Read())
                    {
                        data.Id = reader.GetInt32(0);
                        data.name = reader.GetString(1);
                        data.gender = reader.GetString(2);
                        data.bornDate = reader.GetDateTime(3);
                        data.citizenCard = reader.GetString(4);
                        data.issueDate = reader.GetDateTime(5);
                        data.issuePlace = reader.GetString(6);
                        data.phone = reader.GetString(7);
                        data.email = reader.GetString(8);
                    }
                }

                connection.Close();
            }

            return data;
        }

        public StudentDTO getStudentWithCCCD(string CCCD)
        {
            string query = string.Format("SELECT [Id], [name], [gender], [bornDate], [citizenCard], [issueDate], [issuePlace], [phone], [email] FROM [dbo].[Students] WHERE [citizenCard] = '{0}' ", CCCD);

            StudentDTO data = null;

            using (SqlConnection connection = new SqlConnection(connectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    data = new StudentDTO();
                    // Đọc từng dòng tập kết quả
                    while (reader.Read())
                    {
                        data.Id = reader.GetInt32(0);
                        data.name = reader.GetString(1);
                        data.gender = reader.GetString(2);
                        data.bornDate = reader.GetDateTime(3);
                        data.citizenCard = reader.GetString(4);
                        data.issueDate = reader.GetDateTime(5);
                        data.issuePlace = reader.GetString(6);
                        data.phone = reader.GetString(7);
                        data.email = reader.GetString(8);
                    }
                }

                connection.Close();
            }

            return data;
        }
    }
}
