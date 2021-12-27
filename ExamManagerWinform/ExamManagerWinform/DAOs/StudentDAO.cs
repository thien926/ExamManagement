using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class StudentDAO
    {
        private static StudentDAO instance;
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
    }
}
