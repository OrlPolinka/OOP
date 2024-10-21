using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    public static class StatisticOperation
    {
        // Метод для подсчета суммы элементов множества
        public static int Sum(Set set)
        {
            return set.GetElements().Sum();
        }

        // Метод для нахождения разницы между максимальным и минимальным элементом
        public static int DifferenceBetweenMaxAndMin(Set set)
        {
            if (set.Count == 0)
            {
                throw new InvalidOperationException("Множество пусто.");
            }

            return set.GetElements().Max() - set.GetElements().Min();
        }

        // Метод для подсчета количества элементов
        public static int CountElements(Set set)
        {
            return set.Count;
        }

        // Методы расширения для типа string
        public static int WordCount(this string str)
        {
            return str.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int CountNumbers(this string str)
        {
            return str.Count(char.IsDigit);
        }

        // Методы расширения для класса Set
        public static int Total(this Set set)
        {
            return Sum(set);
        }

        public static int ElementCount(this Set set)
        {
            return CountElements(set);
        }
    }
}