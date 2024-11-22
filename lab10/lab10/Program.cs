using System;
using System.Linq;
using System.Collections.Generic;
using lab10;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int n = 5;
            var selectedMonth = from m in month where m.Length == n select m;
            foreach (var m in selectedMonth) { Console.WriteLine(m); }

            Console.WriteLine("\n");
            selectedMonth = from m in month where Array.IndexOf(month, m) < 2 || (Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8) || Array.IndexOf(month, m) == 11 select m;
            foreach (var m in selectedMonth) { Console.WriteLine(m); }

            Console.WriteLine("\n");
            selectedMonth = from m in month.OrderBy(m => m) select m;
            foreach (var m in selectedMonth) { Console.WriteLine(m); }

            Console.WriteLine("\n");
            selectedMonth = from m in month where m.Contains('u') && m.Length >= 4 select m;
            foreach (var m in selectedMonth) { Console.WriteLine(m); }


            Console.WriteLine("\n");

            List<Phone> phoneCollection = new List<Phone>();
            Phone phone1 = new Phone("Козлов", "Имя 1", "Отчество 1", "Адрес 1", "Номер кредитной карты 1", 1, 11, 21, 0);
            Phone phone2 = new Phone("Орловская", "Имя 2", "Отчество 2", "Адрес 2", "Номер кредитной карты 2", 2, 12, 22, 32);
            Phone phone3 = new Phone("Довнер", "Имя 3", "Отчество 3", "Адрес 3", "Номер кредитной карты 3", 1, 13, 23, 33);
            Phone phone4 = new Phone("Казакова", "Имя 4", "Отчество 4", "Адрес 4", "Номер кредитной карты 4", 4, 14, 24, 0);
            Phone phone5 = new Phone("Яхимчик", "Имя 5", "Отчество 5", "Адрес 5", "Номер кредитной карты 5", 3, 15, 25, 0);
            Phone phone6 = new Phone("Карпенко", "Имя 6", "Отчество 6", "Адрес 6", "Номер кредитной карты 6", 6, 16, 26, 36);
            Phone phone7 = new Phone("Ясенович", "Имя 7", "Отчество 7", "Адрес 7", "Номер кредитной карты 7", 1, 17, 27, 37);
            Phone phone8 = new Phone("Яговдик", "Имя 8", "Отчество 8", "Адрес 8", "Номер кредитной карты 8", 8, 18, 28, 0);
            Phone phone9 = new Phone("Добринец", "Имя 9", "Отчество 9", "Адрес 9", "Номер кредитной карты 9", 4, 19, 29, 39);
            Phone phone10 = new Phone("Кондратчик", "Имя 10", "Отчество 10", "Адрес 10", "Номер кредитной карты 10", 10, 20, 30, 40);

            phoneCollection.Add(phone1);
            phoneCollection.Add(phone2);
            phoneCollection.Add(phone3);
            phoneCollection.Add(phone4);
            phoneCollection.Add(phone5);
            phoneCollection.Add(phone6);
            phoneCollection.Add(phone7);
            phoneCollection.Add(phone8);
            phoneCollection.Add(phone9);
            phoneCollection.Add(phone10);

            //сведения об абонентах, у которых время внутригородских разговоров превышает заданное
            var selectedPhone = from p in phoneCollection where p.TimeCityTalk > 26 select p;
            foreach(var p  in selectedPhone) { Console.WriteLine(p + "\n"); }
            Console.WriteLine("\n");

            // сведения об абонентах, которые пользовались междугородной связью
            selectedPhone = from p in phoneCollection where p.TimeDistanceTalk != 0 select p;
            foreach (var p in selectedPhone) { Console.WriteLine(p + "\n"); }
            Console.WriteLine("\n");

            //количество абонентов с заданным значением дебета
            var count = phoneCollection.Where(p => p.Debit == 1).Count();
            Console.WriteLine(count);
            Console.WriteLine("\n");

            //максимального абонента (по вашему критерию)
            var maxCreditPhone = phoneCollection.Max(p => p.Credit);
            Console.WriteLine(maxCreditPhone);
            Console.WriteLine("\n");

            //упорядоченный список абонентов по фамилии
            selectedPhone = from p in phoneCollection.OrderBy(p => p.Surname) select p;
            foreach (var p in selectedPhone) { Console.WriteLine(p + "\n"); }
            Console.WriteLine("\n\n");



            var complexQuery = phoneCollection
                .GroupBy(p => p.Surname[0])
                .Where(group => group.Count() > 1)
                .OrderByDescending(group => group.Count())
                .Select(group => new
                {
                    Letter = group.Key,
                    TotalCityTalkTime = group.Sum(p => p.TimeCityTalk),
                    Members = group.Select(p => p.Surname).ToList()
                })
                .Where(result => result.TotalCityTalkTime > 24)
                .ToList();

            foreach (var group in complexQuery)
            {
                Console.WriteLine($"Группа по букве: {group.Letter}");
                Console.WriteLine($"Суммарное время внутригородских разговоров: {group.TotalCityTalkTime}");
                Console.WriteLine($"Участники группы: {string.Join(", ", group.Members)}\n");
            }

            Phone[] phones =
            {
                new Phone("Козлов", "Даниил", "Дмитриевич", "Адрес 1", "Номер кредитной карты 1", 1, 34, 21, 0),
                new Phone("Череп", "Елизавета", "Сергеевна", "Адрес 2", "Номер кредитной карты 1", 2, 7, 28, 2),
                new Phone("Валентик", "Полина", "Игоревна", "Адрес 3", "Номер кредитной карты 1", 3, 56, 1, 5),
                new Phone("Глинский", "Александр", "Семенович", "Адрес 4", "Номер кредитной карты 1", 4, 11, 24, 6)
            };

            TV[] tVs =
            {
                new TV("Елизавета", 1999),
                new TV("Дмитрий", 2018),
                new TV("Кристина", 1978),
                new TV("Александр", 2024)
            };

            var peoples = from p in phones
                          join t in tVs on p.Name equals t.Name
                          select new { Name = p.Name, Surname = p.Surname, YearOfProdaction = t.YearOfProdaction };

            foreach(var people in peoples)
            {
                Console.WriteLine(people.ToString());
            }
        }
    }
}