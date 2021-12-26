using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class LevelDAO
    {
        private static LevelDAO instance;
        //private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static LevelDAO Instance { get => (instance == null) ? (instance = new LevelDAO()) : instance; private set => instance = value; }

        private LevelDAO() { }

        public DataTable GetAll() {
            var sql = "SELECT [Id], name AS [Tên trình độ] FROM [Levels]";
            var res = DataProvider.Instance.ExcuteQuery(sql);
            return res;
        }
    }
}
