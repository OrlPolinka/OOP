using System;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.IO;
using lab16;

namespace lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Driver> drivers = new List<Driver>();
            Driver[] dr =
            {
                new Driver(19,"Алексей", 250, true, 2005),
                new Driver(27,"Николай", 300, false, 1999),
                new Driver(22,"Никита", 450, true, 2020),
                new Driver(49,"Александр", 150, true, 2018),
                new Driver(52,"Сергей", 500, true, 2010)
            };

            while (true)
            {
                Console.WriteLine("----------- Необходимо ввести заявку ----------------");
                Console.WriteLine("Введите название товара: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите вес груза: ");
                int weight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите минимальный опыт (лет) водителя для перевозки данного груза: ");
                int workExperience = Convert.ToInt32(Console.ReadLine());

                drivers.Clear();

                for (int i = 0; i < dr.Length; i++)
                {
                    if (dr[i].MaxWeightOfCargo >= weight && dr[i].AgeOfDrive >= workExperience && dr[i].CarCondition)
                    {
                        drivers.Add(dr[i]);
                    }
                }

                if (drivers.Count != 0)
                {
                    foreach (Driver driver in drivers)
                    {
                        Console.WriteLine($"Водитель для вашего груза найден: {driver.DriverName}");
                        Console.WriteLine($"Его характеристики: {driver.ToString()}");
                        if (drivers.Count > 1)
                            Console.WriteLine(new string('-', 50));
                    }
                    Console.WriteLine("Вы желаете отправить еще груз?");
                    string choice = Console.ReadLine();
                    if (choice == "Да" || choice == "да")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("К сожалению подходящий вам водитель найден не был. Желаете повторить заполнение заявки?");
                    string choice = Console.ReadLine();
                    if (choice == "Да" || choice == "да")
                    {
                        Console.Clear();
                        continue;
                    }
                    else 
                    { 
                        return; 
                    }
                }
            }
        }
    }
}