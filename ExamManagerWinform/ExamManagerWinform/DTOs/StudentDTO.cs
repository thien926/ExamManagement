using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DTOs
{
    class StudentDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public DateTime bornDate { get; set; }
        public string citizenCard { get; set; }
        public DateTime issueDate { get; set; }
        public string issuePlace { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
