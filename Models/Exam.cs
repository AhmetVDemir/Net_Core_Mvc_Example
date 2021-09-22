using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public char Answer { get; set; }

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

    }
}
