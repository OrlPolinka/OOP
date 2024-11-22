using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9;
using System.Collections.ObjectModel;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            FurnitureCollection collection = new FurnitureCollection();
            Furniture furniture1 = new Furniture("Шкаф");
            Furniture furniture2 = new Furniture("Стол");
            Furniture furniture3 = new Furniture("Кровать");
            Furniture furniture4 = new Furniture("Кресло");
            Furniture furniture5 = new Furniture("Стул");

            Console.WriteLine("Начальный список мебели");
            collection.Add(furniture1);
            collection.Add(furniture2);
            collection.Add(furniture3);
            collection.Add(furniture4);
            collection.Add(furniture5);

            collection.Display();

            Console.WriteLine("\n\nПоиск индекса по значению");
            Console.WriteLine(collection.IndexOf(furniture3));

            Console.WriteLine("\n\nПоиск значения по индексу");
            Console.WriteLine(collection.Search(2));

            Console.WriteLine("\n\nДобавление нового элемента на место старого");
            Furniture furniture6 = new Furniture("Книжная полка");
            collection.Insert(4, furniture6);
            collection.Display();

            Console.WriteLine("\n\nУдаление элемента по индексу");
            collection.RemoveAt(4);
            collection.Display();

            Console.WriteLine("\n\nУдаление элемента по значению");
            collection.Remove(furniture2);
            collection.Display();

            Console.WriteLine("\n\nУдаление всех элементов");
            collection.Clear();




            ArrayList list = new ArrayList();
            list.Add(2.3);
            list.Add(52);
            list.Add("Строка");
            list.AddRange(new string[] { "Hello", "world" });
            list.AddRange(new int[] { 1, 2, 3 });

            Console.WriteLine("\n\n\nКоллекция ArrayList");
            foreach(var i in list)
            {
                Console.WriteLine(i); 
            }

            Console.WriteLine("\n\nУдаление 3 элементов начиная с третьей позиции");
            list.RemoveRange(3, 3);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            var stack = new Stack();
            foreach(var i in list)
            {
                stack.Push(i);
            }
            Console.WriteLine("\n\nВторая коллекция Stack");
            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("\n\n\n");


            ObservableCollection<Furniture> obsev = new ObservableCollection<Furniture>();

            obsev.CollectionChanged += FurnitureChanged;
            obsev.Add(furniture1);
            obsev.Add(furniture2);
            obsev.Add(furniture3);
            obsev.Add(furniture4);
            obsev.Add(furniture5);

            Console.WriteLine("\n\nObservableCollection");
            foreach (Furniture f in obsev)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("\n\n");

            obsev.RemoveAt(1);
            obsev.Remove(furniture4);

            Console.WriteLine("\n\nObservableCollection");
            foreach(Furniture f in obsev)
            {
                Console.WriteLine(f);
            }

            static void FurnitureChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("Добавлен новый элемент.");
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Удалён элемент.");
                }
            }
        }
    }
}