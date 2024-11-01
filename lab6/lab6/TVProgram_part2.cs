using lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public partial class TVProgram : Director, ITurnOn
    {
        public void Watch()
        {
            Console.WriteLine("Вы смотрите телевизионную программу");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили телевизионную программу");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включена телевизионная программа");
        }

        public override string ToString()
        {
            return Details.ToString();
        }
    }
}
