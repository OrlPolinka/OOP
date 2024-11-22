using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab8;

namespace lab8
{
    public class Technique
    {
        public string Name { get; set; }
        public double Version { get; set; } = 1.0;
        public bool IsActive { get; set; } = false;
        public bool IsBroken { get; set; } = false;
        private int MaxVoltage { get; set; } = 220; //допустимое напряжение

        public Technique(string name)
        {
            Name = name;
        }

        public void Display()
        {
            Console.Write($"Название: {Name}, версия: {Version}, ");
            if (IsBroken)
            {
                Console.WriteLine("техника сломана.");
            }
            else
            {
                Console.WriteLine(IsActive ? "техника включена." : "техника выключена.");
            }
        }

        public void OnUpgrade() { if (!IsBroken) { Version += 1; } else { Console.WriteLine("Техника не может быть обновлена, так как сломана."); } }
        public void Turn_on(int voltage)
        {
            if (IsBroken) {
                Console.WriteLine("Технику нельзя включить, так как она сломана.");
            }
            else if(voltage > MaxVoltage)
            {
                Console.WriteLine("Слишком большое напряжение, техника сломалась.");
                IsBroken = true;
            }
            else
            {
                Console.WriteLine("Техника включена.");
                IsActive = true;
            }
        }
        public void Turn_off(int voltage) { if (!IsBroken) { IsActive = false; Console.WriteLine("Техника выключена."); } }
    }
}
