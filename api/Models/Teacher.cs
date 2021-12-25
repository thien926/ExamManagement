using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }

        public ICollection<Watcher> Watchers { get; set; }
        public Teacher() {
            Watchers = new HashSet<Watcher>();
        }
    }
}