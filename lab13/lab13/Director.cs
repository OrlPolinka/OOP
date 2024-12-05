using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;
namespace lab13
{
    interface ITurnOn
    {
        void Watch();
        void TurnOn();
    }

    [DataContract]
    public abstract class Director
    {
        [DataMember]
        public string Name { get; set; }

        public virtual void TurnOff()
        {
            Console.WriteLine("Выключен кинематогроф режиссера");
        }

        public abstract void TurnOn();
    }

    //телевизионная программа
    [Serializable]
    [DataContract]
    public class TVProgpram : Director, ITurnOn
    {
        //[JsonIgnore]
        [DataMember]
        public int Year { get; set; }
        public TVProgpram()
        {
            Name = "Телевизионная программа";
            Year = 2024;
        }

        public TVProgpram(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключена телевизионная программа");
        }

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
            return $"Название: {this.Name}, Год: {this.Year}";
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
