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
    class RoomDAO
    {
        private static RoomDAO instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static RoomDAO Instance { get => (instance == null) ? (instance = new RoomDAO()) : instance; private set => instance = value; }

        private RoomDAO() { }

        public DataTable GetAll() {
            var sql = "select [Id], name as [Tên phòng thi], examinationId as [Mã khóa thi], levelId as [Mã trình độ] from Rooms";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public Boolean AddRoom(RoomDTO data)
        {
            string query = string.Format("INSERT INTO [dbo].[Rooms] ([name], [examinationId], [levelId], [amount]) VALUES (N'{0}', '{1}', '{2}', '{3}')", data.name, data.examinationId, data.levelId, data.amount);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateRoom(RoomDTO data)
        {
            string query = string.Format("UPDATE [dbo].[Rooms] SET [name] = N'{0}' , [examinationId] = '{1}', [levelId] = '{2}' , [amount] = '{3}' WHERE " +
                "[Id] = {4} ", data.name, data.examinationId, data.levelId, data.amount, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean DeleteRoom(int Id)
        {
            string query = string.Format("DELETE FROM [dbo].[Rooms] WHERE [Id] = {0} ", Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public IEnumerable<RoomDTO> getByExamAndLevel(int examinationId, int levelId)
        {
            // string query = "select [Id], [name] from Rooms";
            string query = string.Format("SELECT [Id], [name], [examinationId], [levelId], [amount] FROM Rooms WHERE [examinationId] = {0} and  [levelId] = {1}", examinationId, levelId);

            List<RoomDTO> data = new List<RoomDTO>();

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
                        RoomDTO room = new RoomDTO();

                        room.Id = reader.GetInt32(0);
                        room.name = reader.GetString(1);
                        room.examinationId = reader.GetInt32(2);
                        room.levelId = reader.GetInt32(3);
                        room.amount = reader.GetInt32(4);

                        data.Add(room);
                    }
                }

                connection.Close();
            }

            return data;
        }

        public Boolean isCreateRoom(int examinationId, int levelId)
        {
            string query = string.Format("SELECT count(*) FROM Rooms WHERE examinationId = {0} and levelId = {1}", examinationId, levelId);
            int res = DataProvider.Instance.ExcuteScalar(query);

            return res > 0;
        }

        public string[] getAllForStudent(int examinationId)
        {
            string query = "SELECT [name] FROM Rooms WHERE [examinationId] = " + examinationId;

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
                        data.Add(reader.GetString(0));
                    }
                }

                connection.Close();
            }

            return data.ToArray<string>();
        }
    }
}
