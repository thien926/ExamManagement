using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RegistionForm
    {
        public int Id { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int studentId { get; set; }

        public virtual Examination examination { get; set; }
        public virtual Level level { get; set; }
        public virtual Student student { get; set; }
    }
}