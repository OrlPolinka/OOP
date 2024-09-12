using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labOOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Примитивные типы данных C#:");
            Console.Write("Введите переменную типа bool: ");
            bool a1 = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"Вывод: { a1 }");

            Console.Write("Введите переменную типа byte: ");
            byte a2 = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Вывод: {a2}");

            Console.Write("Введите переменную типа sbyte: ");
            sbyte a3 = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"Вывод: {a3}");

            Console.Write("Введите переменную типа char: ");
            char a4 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"Вывод: {a4}");

            Console.Write("Введите переменную типа decimal: ");
            decimal a5 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"Вывод: {a5}");

            Console.Write("Введите переменную типа double: ");
            double a6 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Вывод: {a6}");

            Console.Write("Введите переменную типа float: ");
            float a7 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"Вывод: {a7}");

            Console.Write("Введите переменную типа int: ");
            int a8 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Вывод: {a8}");

            Console.Write("Введите переменную типа uint: ");
            uint a9 = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"Вывод: {a9}");

            Console.Write("Введите переменную типа nint: ");
            nint a10 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Вывод: {a10}");

            Console.Write("Введите переменную типа nuint: ");
            nuint a11 = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"Вывод: {a11}");

            Console.Write("Введите переменную типа long: ");
            long a12 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Вывод: {a12}");

            Console.Write("Введите переменную типа ulong: ");
            ulong a13 = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"Вывод: {a13}");

            Console.Write("Введите переменную типа short: ");
            short a14 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Вывод: {a14}");

            Console.Write("Введите переменную типа ushort: ");
            ushort a15 = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"Вывод: {a15}");
            Console.WriteLine();

            //неявное приведение
            double a16 = a8;//int -> double
            long a17 = a8;//int -> long
            double a18 = a7;//float -> double
            int a19 = a4;//char -> int
            int a20 = a14;//short -> int

            //явное привидение
            int a21 = (int)a6;//double -> int
            float a22 = (float)a6;// double -> float
            int a23 = (int)a12;//long -> int
            short a24 = (short)a8;//int -> short
            char a25 = (char)a8;//int -> char

            //упаковка и распаковка значимых типов
            int k = 12345;
            Object obj = k;
            int n = (int)obj;

            //неявно типизированная переменная
            var a26 = 1235;
            Console.Write(a26.GetType()); Console.WriteLine();
            //a26 = true;
            var a27 = new[] { 1, 52, 2, 3, 4, };
            Console.Write(a27.GetType()); Console.WriteLine();

            //пример работы с Nullable
            Nullable<int> a28 = null;
            int? a29 = null;//сокращенная форма

            Console.WriteLine();
            string s1 = "Orlovskaya Polina Valerievna";
            string s2 = "I am a student";
            string s3 = "Hello World";
            Console.WriteLine($"Сравнение строк 1 и 2: {s1 == s2}");
            Console.WriteLine($"Сцепление s1 + s2: {String.Concat(s1, s2)}");
            Console.WriteLine($"Копирование s1: {String.Copy(s1)}");
            Console.WriteLine($"Выделение подстроки: {s3.Substring(4)}");
            string[] s4 = s1.Split();
            Console.WriteLine($"Разделение строки на слова: "); 
            for(int i =  0; i < s4.Length; i++)
            {
                Console.WriteLine(s4[i]);
            }
            Console.WriteLine($"Вставка подстроки в заданную позицию: {s2.Insert(6, s3)}");
            Console.WriteLine($"Удаление заданной подстроки: {s1.Remove(10)}"); Console.WriteLine();

            string s5 = "";
            string s6 = null;
            Console.WriteLine($"Пуста ли строка s5: {String.IsNullOrEmpty(s5)}");
            Console.WriteLine($"Пуста ли строка s6: {String.IsNullOrEmpty(s6)}");
            Console.WriteLine($"Сравнение строк s5 и s6: {s5 == s6}");

            StringBuilder sb = new StringBuilder("Orlovskaya Polina");
            sb.Remove(5, 5);
            sb.Insert(0, "start");
            sb.Append("end"); 
            Console.WriteLine(sb.ToString()); Console.WriteLine();

            int[,] arr = new int[4, 5];
            Random ran = new Random();
            for(int i = 0; i < 4; i++) {
                for(int j = 0; j < 5; j++)
                {
                    arr[i,j] = ran.Next(1,15);
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine() ;

            string[] sarr = new string[] { "hello", "apple", "people", "sleep", "food" };
            for(int i = 0;i < sarr.Length;i++)
            {
                Console.WriteLine(sarr[i]);
            }
            Console.WriteLine($"Длина массива: {sarr.Length}");

            Console.Write("Введите номер позиции элемента, который нужно заменить(0 - {0}): ", sarr.Length-1);
            int position = Convert.ToInt32( Console.ReadLine() );   
            if( position < 0 || position >= sarr.Length)
            {
                Console.Write("Позиция введена неверно! Повторите попытку: ");
                position = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.Write("Введите новое значение: ");
                string newAl = Console.ReadLine();
                sarr[position] = newAl;
            }
            Console.WriteLine("Измененный массив:");
            for (int i = 0; i < sarr.Length; i++)
            {
                Console.WriteLine(sarr[i]);
            }
            Console.WriteLine();

            double[][] darr = new double[3][];
            darr[0] = new double[2];
            darr[1] = new double[3];
            darr[2] = new double[4];
            for (int i = 0; i < darr.Length; i++)
            {
                Console.WriteLine($"Ввод элементов для строки {i + 1}");
                for(int j = 0; j < darr[i].Length; j++)
                {
                    Console.Write($"Элемент [{i}][{j}]: ");
                    darr[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("Заполненный массив:");
            for(int i = 0; i < darr.Length; i++)
            {
                for(int j = 0;j < darr[i].Length; j++)
                {
                    Console.Write(darr[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var Arr = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Вывод массива: ");
            foreach(var number in Arr)
            {
                Console.WriteLine(number);
            }

            var str = "Hello World";
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine();

            ValueTuple<int, string, char, string, ulong> myTuple = (9, "group", 'P', "name", 18);
            Console.WriteLine($"Кортеж: {myTuple}");
            Console.WriteLine("Выборочный вывод кортежа:");
            Console.WriteLine(myTuple.Item1);
            Console.WriteLine(myTuple.Item3);
            Console.WriteLine(myTuple.Item4);
            Console.WriteLine();

            var (intValue, strValue1, charValue, strValue2, ulongValue) = myTuple;
            Console.WriteLine("Распаковка кортежа:");
            Console.WriteLine($"intValue: {intValue}");
            Console.WriteLine($"strValue1: {strValue1}");
            Console.WriteLine($"charValue: {charValue}");
            Console.WriteLine($"strValue2: {strValue2}");
            Console.WriteLine($"ulongValue: {ulongValue}");
            Console.WriteLine();

            var (_, _, specificValue, _, _) = myTuple;
            Console.WriteLine($"Специальное значение третьего элемента: {specificValue}");
            Console.WriteLine();

            ValueTuple<int, string, char, string, ulong> myTuple2 = (9, "group", 'P', "name", 18);
            ValueTuple<int, string, char, string, ulong> myTuple3 = (12, "groups", 'a', "names", 23);
            Console.WriteLine("Сравнение кортежей:");
            Console.WriteLine($"myTuple == myTuple2: {myTuple == myTuple2}");
            Console.WriteLine($"myTuple == myTuple3: {myTuple == myTuple3}");
            Console.WriteLine();

            int[] array = new int[] { 1, 2, 3, 4, 5};
            string str1 = "Hello World";
            (int max, int min, int sum, char letter) locFunc(int[] arr, string str)
            {
                int max = arr[0];
                int min = arr[0];
                int sum = 0;

                foreach(int i in arr)
                {
                    if( i > max) max = i;
                    if( i < min) min = i;
                    sum += i;
                }

                char letter = str1[0];

                return (max, min, sum, letter);
            }
            var result = locFunc(array, str1);
            Console.WriteLine($"Максимальный элемент массива: {result.max}");
            Console.WriteLine($"Минимальный элемент массива: {result.min}");
            Console.WriteLine($"Сумма элементов массива: {result.sum}");
            Console.WriteLine($"Первая буква строки: {result.letter}");
            Console.WriteLine();

            void checkedBlock()
            {
                int maxInt = int.MaxValue;
                try
                {
                    int result = checked(maxInt + 1);
                    Console.WriteLine($"Результат в блоке checked:{result}");
                }
                catch(OverflowException ex)
                {
                    Console.WriteLine($"Исключение в блоке checked: {ex.Message}");
                }
            }

            void uncheckedBlock()
            {
                int maxInt = int.MaxValue;
                int result = unchecked(maxInt + 1);
                Console.WriteLine($"Результат в блоке unchecked: {result}");
            }

            checkedBlock();
            uncheckedBlock();
        }
    }
}