using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;

namespace lab5
{
    class Printer
    {
        public void IAmPrinting(Director director)
        {
            Console.WriteLine(director.ToString());
        }
    }
}
