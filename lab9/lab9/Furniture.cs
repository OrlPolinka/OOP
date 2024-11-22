using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9;

namespace lab9
{
    class Furniture
    {
        public string Name { get; set; }
        public Furniture() { Name = "name"; }
        public Furniture(string name) {  Name = name; }
        public override string ToString() { return Name; }
    }
}
