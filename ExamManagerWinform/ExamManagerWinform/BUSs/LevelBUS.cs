using ExamManagerWinform.DAOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.BUSs
{
    class LevelBUS
    {
        public DataTable GetAll()
        {
            return LevelDAO.Instance.GetAll();
        }
    }
}
