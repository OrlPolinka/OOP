using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using lab7;

namespace lab7
{
    public class TVProgram
    {
        public string Name { get; set; }
        public TVProgram()
        {
            Name = "Телевизионная программа";
        }

        public TVProgram(string name)
        {
            Name = name;
        }

        public void TurnOff()
        {
            Console.WriteLine("Выключена телевизионная программа");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите телевизионную программу");
        }

        void TurnOn()
        {
            Console.WriteLine("Включена телевизионная программа");
        }

        public override string ToString()
        {
            return $"\nНазвание: {this.Name}";
        }
    }
}
