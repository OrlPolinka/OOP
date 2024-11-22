using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using lab7;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> intSet = new Set<int>(new List<int> { 1, 2, 3, 4, 5 });

            try
            {
                intSet.Add(11);
                intSet.Add(12);
                intSet.Add(13);
                intSet.Add(14);
                intSet.Remove(5);
                intSet.Remove(12);
                intSet.Remove(6);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            Console.WriteLine("Set с типом данных int:");
            intSet.Seen();

            Console.WriteLine("Set с типом данных char:");
            Set<char> charSet = new Set<char>();
            charSet.Add('a');
            charSet.Add('b');
            charSet.Add('c');
            charSet.Seen();

            Console.WriteLine("Set с типом данных double:");
            Set<double> doubleSet = new Set<double>();
            doubleSet.Add(1.5);
            doubleSet.Add(56.4);
            doubleSet.Add(-98.123);
            doubleSet.Seen();

            Console.WriteLine("Set с типом данных TVProgram:");
            Set<TVProgram> TVSet = new Set<TVProgram>();
            TVSet.Add(new TVProgram("Телевизионная программа_1"));
            TVSet.Add(new TVProgram("Телевизионная программа_2"));
            TVSet.Add(new TVProgram("Телевизионная программа_3"));
            TVSet.Seen();


            TVSet.SaveToFile("tvSet.json");

            Set<TVProgram> TVSetFromJSON = new Set<TVProgram>();
            TVSetFromJSON.LoadFromFile("tvSet.json");
            Console.WriteLine("Загруженное множество TVProgram из файла:");
            TVSetFromJSON.Seen();


            intSet.SaveToFile("intSet.json");

            Set<int> intSetFromJSON = new Set<int>();
            intSetFromJSON.LoadFromFile("intSet.json");
            Console.WriteLine("Загруженное множество Set из файла:");
            intSetFromJSON.Seen();
        }
    }
}