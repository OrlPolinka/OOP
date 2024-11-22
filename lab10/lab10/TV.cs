using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab10;

namespace lab10
{
    class TV
    {
        public string Name {  get; set; }
        public int YearOfProdaction { get; set; }

        public TV(string name, int yearOfProdaction)
        {
            Name = name;
            YearOfProdaction = yearOfProdaction;
        }

        public TV()
        {
            Name = "name";
            YearOfProdaction = 2000;
        }
    }
}
