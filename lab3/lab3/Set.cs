using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    public class Set
    {
        // Вложенный класс Production
        public class Production
        {
            public int Id { get; set; }
            public string OrganizationName { get; set; }

            public Production(int id, string organizationName)
            {
                Id = id;
                OrganizationName = organizationName;
            }
        }

        // Вложенный класс Developer
        public class Developer
        {
            public string FullName { get; set; }
            public int Id { get; set; }
            public string Department { get; set; }

            public Developer(string fullName, int id, string department)
            {
                FullName = fullName;
                Id = id;
                Department = department;
            }
        }

        public Production ProductionInfo { get; set; }
        public Developer DeveloperInfo { get; set; }

        private HashSet<int> elements; // Используем HashSet для уникальности элементов

        // Конструктор по умолчанию
        public Set()
        {
            elements = new HashSet<int>();
        }

        // Конструктор с параметрами (принимает коллекцию элементов)
        public Set(IEnumerable<int> initialElements)
        {
            elements = new HashSet<int>(initialElements);
        }

        // Свойство для доступа к количеству элементов
        public int Count => elements.Count;

        // Метод для добавления элемента в Set
        public void Add(int el)
        {
            elements.Add(el);
        }

        // Метод для проверки наличия элемента
        public bool Contains(int el)
        {
            return elements.Contains(el);
        }

        // Метод для удаления элемента
        public bool Remove(int el)
        {
            return elements.Remove(el);
        }

        // Индексатор для доступа к элементу по индексу
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= elements.Count)
                {
                    throw new IndexOutOfRangeException("Индекс вне диапазона");
                }
                return elements.ElementAt(index);
            }
        }

        // Перегрузка оператора '>' - проверка на принадлежность
        public static bool operator <(Set a, int b)
        {
            return !a.Contains(b);
        }
        // Перегрузка оператора '>' - проверка на принадлежность
        public static bool operator >(Set a, int b)
        {
            return a.Contains(b);
        }

        // Перегрузка оператора '<' - проверка на подмножество
        public static bool operator >(Set a, Set b)
        {
            return !a.elements.IsSubsetOf(b.elements);
        }
        // Перегрузка оператора '<' - проверка на подмножество
        public static bool operator <(Set a, Set b)
        {
            return a.elements.IsSubsetOf(b.elements);
        }

        // Перегрузка оператора '*' - пересечение множеств
        public static Set operator *(Set a, Set b)
        {
            return new Set(a.elements.Intersect(b.elements));
        }

        // Явное преобразование множества к типу DateTime
        public DateTime Date()
        {
            int sum = elements.Sum();
            return new DateTime(2024, 10, 1).AddDays(sum);
        }

        // Метод для вывода на экран
        public void Display()
        {
            Console.Write("Set: { ");
            foreach (var element in elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("}");
        }

        // Переопределение метода ToString() для корректного вывода содержимого множества
        public override string ToString()
        {
            return "{" + string.Join(", ", elements) + "}";
        }

        // Метод для возврата элементов для методов расширения
        public IEnumerable<int> GetElements()
        {
            return elements;
        }
    }
}