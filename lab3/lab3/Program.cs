using System;
using System.Collections.Generic;
using lab3;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание двух множеств
            Set set1 = new Set(new List<int> { 1, 2, 3, 4, 5 });
            Set set2 = new Set(new List<int> { 4, 5, 6, 7, 8 });

            // Вывод на экран
            Console.WriteLine("Исходные Sets:");
            set1.Display();
            set2.Display();

            // Инициализация вложенного класса Production
            set1.ProductionInfo = new Set.Production(52, "Название организации");
            Console.WriteLine($"\nProduction ID: {set1.ProductionInfo.Id}, Name: {set1.ProductionInfo.OrganizationName}");

            // Инициализация вложенного класса Developer
            set1.DeveloperInfo = new Set.Developer("Орловская Полина Валерьевна", 17, "Тестирование");
            Console.WriteLine($"Developer: {set1.DeveloperInfo.FullName}, ID: {set1.DeveloperInfo.Id}, Department: {set1.DeveloperInfo.Department}");

            // Использование статического класса StatisticOperation
            Console.WriteLine($"\nСумма элементов: {StatisticOperation.Sum(set1)}");
            Console.WriteLine($"Разница между максимальным и минимальным: {StatisticOperation.DifferenceBetweenMaxAndMin(set1)}");
            Console.WriteLine($"Количество элементов: {StatisticOperation.CountElements(set1)}");

            // Тестирование методов расширения для строки
            string testString1 = "Я студент 5 БГТУ 96 ФИТ в 7 Минске";
            Console.WriteLine($"\nКоличество слов: {testString1.WordCount()}");
            Console.WriteLine($"Количество цифр: {testString1.CountNumbers()}");

            // Использование методов расширения для Set
            Console.WriteLine($"\nОбщая сумма элементов множества: {set1.Total()}");
            Console.WriteLine($"Количество элементов в множестве: {set1.ElementCount()}");

            // Тестирование оператора >
            Console.WriteLine("\nТестирование оператора >:");
            Console.WriteLine($"Присутствует ли 3 в set1? {(set1 > 3)}");
            Console.WriteLine($"Присутствует ли 6 в set1? {(set1 > 6)}");

            // Тестирование оператора <
            Set subset = new Set(new List<int> { 2, 3 });
            Console.WriteLine("\nТестирование оператора <:");
            Console.WriteLine($"Является ли {{2, 3}} подмножеством set1? {(subset < set1)}");
            Console.WriteLine($"Является ли set1 подмножеством set2? {(set1 < set2)}");

            // Тестирование оператора *
            Set intersection = set1 * set2;
            Console.WriteLine("\nТестирование оператора *:");
            Console.WriteLine("Пересечение Set1 и Set2: " + intersection);

            // Тестирование метода Date
            Console.WriteLine("\nТестирование метода Date:");
            DateTime date = set1.Date();
            Console.WriteLine("Дата из Set1: " + date.ToShortDateString());

            // Тестирование индексатора
            Console.WriteLine("\nТестирование индексатора:");
            try
            {
                Console.WriteLine($"Элемент с индексом 2 в Set1: {set1[2]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Тестирование метода расширения FirstNumber
            string testString2 = "abc123def456";
            Console.WriteLine("\nТестирование метода FirstNumber:");
            int firstNumber = set1.FirstNumber(testString2);
            Console.WriteLine($"Первое число в строке '{testString2}': {firstNumber}");

            // Тестирование метода расширения RemovePositiveElements
            Console.WriteLine("\nТестирование метода RemovePositiveElements на Set1:");
            set1.RemovePositiveElements();
            Console.WriteLine("Set1 после удаления положительных элементов: " + set1);

            // Добавление некоторых отрицательных и положительных чисел
            set1.Add(-1);
            set1.Add(-2);
            set1.Add(3);
            Console.WriteLine("\nSet1 после добавления -1, -2, 3: " + set1);
            set1.RemovePositiveElements();
            Console.WriteLine("Set1 после удаления положительных элементов: " + set1);

        }
    }
}