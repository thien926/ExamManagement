using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class RegistionFormDAO
    {
        private static RegistionFormDAO instance;
        internal static RegistionFormDAO Instance { get => (instance == null) ? (instance = new RegistionFormDAO()) : instance; private set => instance = value; }

        private RegistionFormDAO() { }

        public DataTable GetWithExamLevel(int examinationId, int levelId, string citizenCard) {
            var sql = "";
            if(string.IsNullOrEmpty(citizenCard))
            {
                sql = string.Format("SELECT r.Id, s.Id as [Mã thí sinh], s.citizenCard as [CCCD], s.name as [Tên thí sinh], r.examinationId as [Mã khóa thi], r.levelId as [Mã trình độ], CONVERT(varchar, r.status) as [Trạng thái] FROM RegistionForms as r, Students as s WHERE r.studentId = s.Id and r.examinationId = {0} AND r.levelId = {1}", examinationId, levelId);
            }
            else
            {
                sql = string.Format("SELECT r.Id, s.Id as [Mã thí sinh], s.citizenCard as [CCCD], s.name as [Tên thí sinh], r.examinationId as [Mã khóa thi], r.levelId as [Mã trình độ], CONVERT(varchar, r.status) as [Trạng thái] FROM RegistionForms as r, Students as s WHERE r.studentId = s.Id and r.examinationId = {0} AND r.levelId = {1} AND s.citizenCard LIKE '%{2}%'", examinationId, levelId, citizenCard);
            }
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }

        public Boolean AddRegistionForm(RegistionFormDTO data)
        {
            int statusInt = (data.status) ? 1 : 0;
            string query = string.Format("INSERT INTO [dbo].[RegistionForms] ([examinationId], [levelId], [studentId], [status]) VALUES ({0}, {1}, {2}, {2})", data.examinationId, data.levelId, data.studentId, statusInt);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateStatusRegistionForm(RegistionFormDTO data)
        {
            int statusInt = (data.status) ? 1 : 0;
            string query = string.Format("UPDATE [dbo].[RegistionForms] SET [status] = {0}  WHERE [Id] = {1} ", statusInt, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }
    }
}
