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
    class TeacherBUS
    {
        public DataTable GetAll()
        {
            return TeacherDAO.Instance.GetAll();
        }

        public Boolean AddTeacher(string name, string gender, string phone)
        {
            var data = new TeacherDTO();
            data.name = name;
            data.gender = gender;
            data.phone = phone;
            return TeacherDAO.Instance.AddTeacher(data);
            
        }

        public Boolean UpdateTeacher(int Id, string name, string gender, string phone)
        {
            var data = new TeacherDTO();
            data.Id = Id;
            data.name = name;
            data.gender = gender;
            data.phone = phone;
            return TeacherDAO.Instance.UpdateTeacher(data);

        }

        public Boolean DeleteTeacher(int Id)
        {
            return TeacherDAO.Instance.DeleteTeacher(Id);
        }
    }
}
