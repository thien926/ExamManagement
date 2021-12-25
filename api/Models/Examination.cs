using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime examDate { get; set; }

        public ICollection<RegistionForm> RegistionForms { get; set; }
        public ICollection<Room> Rooms { get; set; }

        public Examination() {
            RegistionForms = new HashSet<RegistionForm>();
            Rooms = new HashSet<Room>();
        }
    }
}