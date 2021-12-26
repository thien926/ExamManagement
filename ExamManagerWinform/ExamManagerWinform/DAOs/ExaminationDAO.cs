using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class ExaminationDAO
    {
        private static ExaminationDAO instance;
        internal static ExaminationDAO Instance { get => (instance == null) ? (instance = new ExaminationDAO()) : instance; private set => instance = value; }

        private ExaminationDAO() { }

        public DataTable GetAll() {
            var sql = "select [Id], name as [Tên khóa thi], examDate as [Ngày thi] from Examinations";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }
    }
}
