using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace lab7
{
    interface IUseSet<T>
    {
        public void Add(T elem);
        public bool Remove(T elem);
        public void Seen();

    }

    public class Set<T> : IUseSet<T>// where T : class
    {
        private HashSet<T> elements; // Используем HashSet для уникальности элементов

        // Конструктор по умолчанию
        public Set()
        {
            elements = new HashSet<T>();
        }

        // Конструктор с параметрами (принимает коллекцию элементов)
        public Set(IEnumerable<T> initialElements)
        {
            elements = new HashSet<T>(initialElements);
        }

        // Свойство для доступа к количеству элементов
        public int Count => elements.Count;

        // Метод для добавления элемента в Set
        public void Add(T elem)
        {
            elements.Add(elem);
        }

        public void Seen()
        {
            Console.Write("Set: { ");
            foreach (var element in elements)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("}");
        }

        // Метод для проверки наличия элемента
        public bool Contains(T elem)
        {
            return elements.Contains(elem);
        }

        // Метод для удаления элемента
        public bool Remove(T elem)
        {
            return elements.Remove(elem);
        }



        // Метод для записи в файл JSON
        public void SaveToFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                var json = JsonSerializer.Serialize(elements, options);

                File.WriteAllText(filePath, json);
                Console.WriteLine($"Данные успешно сохранены в файл {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        // Метод для чтения из файла JSON
        public void LoadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    elements = JsonSerializer.Deserialize<HashSet<T>>(json) ?? new HashSet<T>();
                    Console.WriteLine($"Данные успешно загружены из файла {filePath}");
                }
                else
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
        }




        // Перегрузка оператора '>' - проверка на принадлежность
        public static bool operator <(Set<T> a, T b)
        {
            return !a.Contains(b);
        }
        // Перегрузка оператора '>' - проверка на принадлежность
        public static bool operator >(Set<T> a, T b)
        {
            return a.Contains(b);
        }

        // Перегрузка оператора '<' - проверка на подмножество
        public static bool operator >(Set<T> a, Set<T> b)
        {
            return !a.elements.IsSubsetOf(b.elements);
        }
        // Перегрузка оператора '<' - проверка на подмножество
        public static bool operator <(Set<T> a, Set<T> b)
        {
            return a.elements.IsSubsetOf(b.elements);
        }

        // Перегрузка оператора '*' - пересечение множеств
        public static Set<T> operator *(Set<T> a, Set<T> b)
        {
            return new Set<T>(a.elements.Intersect(b.elements));
        }

        // Явное преобразование множества к типу DateTime
        public DateTime Date()
        {
            try
            {
                int sum = elements.OfType<int>().Sum();
                return new DateTime(2024, 10, 1).AddDays(sum);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Тип T должен быть числовым для вычисления даты.");
            }
        }

        

        // Переопределение метода ToString() для корректного вывода содержимого множества
        public override string ToString()
        {
            return "{" + string.Join(", ", elements) + "}";
        }
    }
}
