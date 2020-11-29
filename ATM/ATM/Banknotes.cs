using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Banknotes
    {
        public int Nominal { get; set; }
        public int Count { get; set; }
        public Banknotes(int nominal, int count)
        {
            Nominal = nominal;
            Count = count;
        }
    }
}
