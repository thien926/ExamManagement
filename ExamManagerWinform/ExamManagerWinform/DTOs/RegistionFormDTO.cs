using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DTOs
{
    class RegistionFormDTO
    {
        public int Id { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int studentId { get; set; }
        public Boolean status { get; set; }
    }
}
