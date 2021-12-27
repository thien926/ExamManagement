using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string name { get; set; }
        // public TimeSpan beginTime { get; set; }
        // public TimeSpan endTime { get; set; }
        public int examinationId { get; set; }
        public int levelId { get; set; }
        public int amount { get; set; }

        public virtual Examination examination { get; set; }
        public virtual Level level { get; set; }
        public ICollection<Watcher> Watchers { get; set; }
        public ICollection<Result> Results { get; set; }
        public Room() {
            Watchers = new HashSet<Watcher>();
            Results = new HashSet<Result>();
        }
    }
}