using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXC.Models
{
    public class DonusCevap
    {
        public string Cevap { get; set; }
        public DonusCevap(string cevap)
        {
            Cevap = cevap;
        }
        
    }
}
