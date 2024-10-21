using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    // Класс с методами расширения
    public static class SetExtensions
    {
        public static int FirstNumber(this Set set, string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            string number = string.Empty;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    number += c;
                else if (number.Length > 0)
                    break;
            }

            if (number.Length > 0)
                return int.Parse(number); // Преобразуем строку в число

            return 0;
        }

        public static void RemovePositiveElements(this Set set)
        {
            // Собираем элементы для удаления
            List<int> toRemove = new List<int>();
            foreach (var elem in set.GetElements())
            {
                if (elem > 0)
                {
                    toRemove.Add(elem);
                }
            }

            foreach (var elem in toRemove)
            {
                set.Remove(elem);
            }
        }
    }
}