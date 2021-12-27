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
    class StudentBUS
    {
        public DataTable GetAll()
        {
            return StudentDAO.Instance.GetAll();
        }

        public Boolean AddStudent(string name, string gender, DateTime bornDate, string citizenCard, DateTime issueDate, string issuePlace, string phone, string email)
        {
            var data = new StudentDTO();
            data.name = name;
            data.gender = gender;
            data.bornDate = bornDate;
            data.citizenCard = citizenCard;
            data.issueDate = issueDate;
            data.issuePlace = issuePlace;
            data.email = email;
            data.phone = phone;
            return StudentDAO.Instance.AddStudent(data);
            
        }

        public Boolean UpdateStudent(int Id, string name, string gender, DateTime bornDate, string citizenCard, DateTime issueDate, string issuePlace, string phone, string email)
        {
            var data = new StudentDTO();
            data.Id = Id;
            data.name = name;
            data.gender = gender;
            data.bornDate = bornDate;
            data.citizenCard = citizenCard;
            data.issueDate = issueDate;
            data.issuePlace = issuePlace;
            data.email = email;
            data.phone = phone;
            return StudentDAO.Instance.UpdateStudent(data);

        }

        public Boolean DeleteStudent(int Id)
        {
            return StudentDAO.Instance.DeleteStudent(Id);
        }
    }
}
