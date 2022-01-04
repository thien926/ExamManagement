using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DTOs
{
    class RoomDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int amount { get; set; }
    }
}
