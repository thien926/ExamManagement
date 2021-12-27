using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class TeacherDAO
    {
        private static TeacherDAO instance;
        internal static TeacherDAO Instance { get => (instance == null) ? (instance = new TeacherDAO()) : instance; private set => instance = value; }

        private TeacherDAO() { }

        public DataTable GetAll() {
            var sql = "select [Id], name as [Tên giáo viên], gender as [Giới tính], phone as [Số điện thoại] from Teachers";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public Boolean AddTeacher(TeacherDTO data)
        {
            string query = string.Format("INSERT INTO [dbo].[Teachers] ([name] ,[gender], [phone]) VALUES (N'{0}', N'{1}', '{2}')", data.name, data.gender, data.phone);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateTeacher(TeacherDTO data)
        {
            string query = string.Format("UPDATE [dbo].[Teachers] SET [name] = N'{0}' , [gender] = N'{1}' , [phone] = '{2}' WHERE " +
                "[Id] = {3} ", data.name, data.gender, data.phone, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean DeleteTeacher(int Id)
        {
            string query = string.Format("DELETE FROM [dbo].[Teachers] WHERE [Id] = {0} ", Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }
    }
}
