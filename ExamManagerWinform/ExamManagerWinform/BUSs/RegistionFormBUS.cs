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
    class RegistionFormBUS
    {
        public DataTable GetWithExamLevel(int examinationId, int levelId, string citizenCard)
        {
            return RegistionFormDAO.Instance.GetWithExamLevel(examinationId, levelId, citizenCard);
        }

        public Boolean AddRegistionForm(int examinationId, int levelId, int studentId, Boolean status) {
            var data = new RegistionFormDTO();
            data.examinationId = examinationId;
            data.levelId = levelId;
            data.studentId = studentId;
            data.status = status;
            return RegistionFormDAO.Instance.AddRegistionForm(data);
        }

        public Boolean UpdateStatusRegistionForm(int Id, Boolean status)
        {
            var data = new RegistionFormDTO();
            data.Id = Id;
            data.status = status;
            return RegistionFormDAO.Instance.UpdateStatusRegistionForm(data);
        }
    }
}
