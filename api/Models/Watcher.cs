using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Watcher
    {
        public int roomId { get; set; }
        public int teacherId { get; set; }
        public virtual Room room { get; set; }
        public virtual Teacher teacher { get; set; }
    }
}