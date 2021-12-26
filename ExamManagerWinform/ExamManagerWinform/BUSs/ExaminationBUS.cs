using ExamManagerWinform.DAOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.BUSs
{
    class ExaminationBUS
    {
        public DataTable GetAll()
        {
            return ExaminationDAO.Instance.GetAll();
        }
    }
}
