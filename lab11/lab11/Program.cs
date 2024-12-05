using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using lab11;

namespace lab11
{
    class Program
    {
        #region director
        interface ITurnOn
        {
            void Watch();
            void TurnOn();
        }

        public abstract class Director
        {
            public string Name { get; set; }

            public virtual void TurnOff()
            {
                Console.WriteLine("Выключен кинематогроф режиссера");
            }

            public abstract void TurnOn();
        }

        //телевизионная программа
        public class TVProgpram : Director, ITurnOn
        {
            public TVProgpram()
            {
                Name = "Телевизионная программа";
            }

            public TVProgpram(string name)
            {
                Name = name;
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
                return $"Тип: {this.GetType()}, Название: {this.Name}";
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

        //фильм
        public class Movie : Director, ITurnOn
        {
            public Movie()
            {
                Name = "Фильм";
            }

            public Movie(string name)
            {
                Name = name;
            }

            public override void TurnOff()
            {
                Console.WriteLine("Выключен фильм");
            }

            public void Watch()
            {
                Console.WriteLine("Вы смотрите фильм");
            }

            public override void TurnOn()
            {
                Console.WriteLine("Вы включили фильм");
            }

            void ITurnOn.TurnOn()
            {
                Console.WriteLine("Включен фильм");
            }
            public override string ToString()
            {
                return $"Тип: {this.GetType()}, Название: {this.Name}";
            }
        }

        //новости
        public class News : Director, ITurnOn
        {
            public News()
            {
                Name = "Новости";
            }

            public News(string name)
            {
                Name = name;
            }

            public override void TurnOff()
            {
                Console.WriteLine("Выключены новости");
            }

            public void Watch()
            {
                Console.WriteLine("Вы смотрите новости");
            }

            public override void TurnOn()
            {
                Console.WriteLine("Вы включили новости");
            }

            void ITurnOn.TurnOn()
            {
                Console.WriteLine("Включены новости");
            }
            public override string ToString()
            {
                return $"Тип: {this.GetType()}, Название: {this.Name}";
            }
        }

        //художественный фильм
        public class FeatureFilm : Director, ITurnOn
        {
            public FeatureFilm()
            {
                Name = "Художественный фильм";
            }

            public FeatureFilm(string name)
            {
                Name = name;
            }

            public override void TurnOff()
            {
                Console.WriteLine("Выключен художественный фильм");
            }

            public void Watch()
            {
                Console.WriteLine("Вы смотрите художественный фильм");
            }

            public override void TurnOn()
            {
                Console.WriteLine("Вы включили художественный фильм");
            }

            void ITurnOn.TurnOn()
            {
                Console.WriteLine("Включен художественный фильм");
            }
            public override string ToString()
            {
                return $"Тип: {this.GetType()}, Название: {this.Name}";
            }
        }

        //sealed-класс(запечатанный) мультфильм
        public sealed class Cartoon : Director, ITurnOn
        {
            public Cartoon()
            {
                Name = "Мультфильм";
            }

            public Cartoon(string name)
            {
                Name = name;
            }

            public override void TurnOff()
            {
                Console.WriteLine("Выключен мультфильм");
            }

            public void Watch()
            {
                Console.WriteLine("Вы смотрите мультфильм");
            }

            public override void TurnOn()
            {
                Console.WriteLine("Вы включили мультфильм");
            }

            void ITurnOn.TurnOn()
            {
                Console.WriteLine("Включен мультфильм");
            }
            public override string ToString()
            {
                return $"Тип: {this.GetType()}, Название: {this.Name}";
            }
        }

        //реклама
        public class Advertising : Director, ITurnOn
        {
            public Advertising()
            {
                Name = "Реклама";
            }

            public Advertising(string name)
            {
                Name = name;
            }

            public override void TurnOff()
            {
                Console.WriteLine("Выключена реклама");
            }

            public void Watch()
            {
                Console.WriteLine("Вы смотрите рекламу");
            }

            public override void TurnOn()
            {
                Console.WriteLine("Вы включили рекламу");
            }

            void ITurnOn.TurnOn()
            {
                Console.WriteLine("Включена реклама");
            }
            public override string ToString()
            {
                return $"Тип: {this.GetType()}, Название: {this.Name}";
            }
            #endregion



            static void Main(string[] args)
            {
                Reflector.getNameAssembly("lab11.Program+Director");
                Console.WriteLine("Имя сборки определено и записано в файл");

                Reflector.publicConstructor("lab11.Program+Director");
                Console.WriteLine("Информация о наличии публичных конструктуров класса 'lab11.Program+Director' была записана в файл");

                Reflector.publicMethod("lab11.Program+Director");
                Console.WriteLine("Публичные методы класса 'lab11.Program+Director' были записаны в файл.");

                Reflector.fieldsAndProperties("lab11.Program+Director");
                Console.WriteLine("Поля и свойства класса 'lab11.Program+Director' были записаны в файл.");

                Reflector.getInterface("lab11.Program+Director");
                Console.WriteLine("Интерфейсы класса 'lab11.Program+Director' были записаны в файл.");

                Reflector.getNameOfMethods("lab11.Program+Director", "String");
                Console.WriteLine("Методы которые включают параметр типа 'String' класса 'lab11.Program+Director' были записаны в файл.\n");

                Director dir = Reflector.Create<Movie>();
                Console.WriteLine(dir + "\n");

                string[] lines = File.ReadAllLines("File.txt");
                object[] fileParameters = lines.Select(line => (object)line).ToArray();
                Movie movie = new Movie("Фильм");
                Reflector.methodInvoke(movie, "TurnOn", fileParameters);


            }
        }
    }
}