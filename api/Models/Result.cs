using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string examRoom { get; set; }
        public string SBD { get; set; }
        public float pointListen { get; set; }
        public float pointSpeak { get; set; }
        public float pointWrite { get; set; }
        public float pointRead { get; set; }
        public int roomId { get; set; }
        public int studentId { get; set; }
        

        public virtual Room room { get; set; }
        public virtual Student student { get; set; }
    }
}