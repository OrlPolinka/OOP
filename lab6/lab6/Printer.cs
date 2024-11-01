using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6; 

namespace lab6
{
    class Printer
    {
        public void IAmPrinting(Director director)
        {
            Console.WriteLine(director.ToString());
        }
    }
}
