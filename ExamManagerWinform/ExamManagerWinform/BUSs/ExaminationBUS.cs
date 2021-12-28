using ExamManagerWinform.DAOs;
using ExamManagerWinform.DTOs;
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

        public Boolean AddExamination(string name, DateTime examDate)
        {
            var data = new ExaminationDTO();
            data.name = name;
            data.examDate = examDate;
            return ExaminationDAO.Instance.AddExamination(data);
            
        }

        public Boolean UpdateExamination(int Id, string name, DateTime examDate)
        {
            var data = new ExaminationDTO();
            data.Id = Id;
            data.name = name;
            data.examDate = examDate;
            return ExaminationDAO.Instance.UpdateExamination(data);

        }

        public Boolean DeleteExamination(int Id)
        {
            return ExaminationDAO.Instance.DeleteExamination(Id);
        }

        public string[] getAllForRegister() {
            return ExaminationDAO.Instance.getAllForRegister();
        }
    }
}
