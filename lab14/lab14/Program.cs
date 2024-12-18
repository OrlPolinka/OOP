using System;
using System.Diagnostics;
using System.Reflection;
using System.Timers;
using System.Threading;
using lab14;

namespace lab14
{
    class Program
    {
        static ManualResetEvent pauseEvent = new ManualResetEvent(true);    // Изначально в сигнальном состоянии
        static object locker = new object();    // объект-заглушка
        static bool isEven = false;
        static bool isOdd = true;
        static bool workComplete = false; // Флаг завершения работы потоков
        static void Main(string[] args)
        {
            //1
            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                Console.WriteLine($"ID: {process.Id}");
                Console.WriteLine($"Имя: {process.ProcessName}");
                Console.WriteLine($"Приоритет: {process.BasePriority}");
                try
                {
                    Console.WriteLine($"Время запуска: {process.StartTime}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Время запуска: недоступно ({ex.Message})");
                }
                Console.WriteLine($"Текущее состояние: {process.Responding}");
                Console.WriteLine($"Объем выделенной виртуальной памяти: {process.VirtualMemorySize64}");
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine();


            //2
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName}");
            Console.WriteLine($"Детали конфигурации: {domain.SetupInformation}");
            Console.WriteLine($"Базовый каталог: {domain.BaseDirectory}");
            Console.WriteLine("Все сборки, загруженные в домен:");
            foreach(Assembly assembly in domain.GetAssemblies())
            {
                Console.WriteLine(assembly.GetName().Name);
            }
            Console.WriteLine();
            //AppDomain newD = AppDomain.CreateDomain("New");
            //newD.Load("System.Console");
            //AppDomain.Unload(newD);


            //3
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Console.WriteLine("Введите n:");
            int n = int.Parse(Console.ReadLine());
            Thread thread = new Thread(() => Calculate(n));
            thread.Name = "Calculate";
            thread.Start();
            Console.WriteLine($"Имя потока: {thread.Name}");
            Console.WriteLine($"Приоритет: {thread.Priority}");
            Console.WriteLine($"Статус потока: {thread.ThreadState}");
            Console.WriteLine($"Числовой идентификатор: {thread.ManagedThreadId}");
            Thread.Sleep(3000);
            pauseEvent.Reset();  // приостановлено
            Console.WriteLine("Работа потока приостановлена");
            pauseEvent.Set();   // возобновляет работу
            cancellationTokenSource.Cancel();
            thread.Join();      // ожидание завершения
            Console.WriteLine("Работа потока завершена.");
            Console.WriteLine();


            //4
            using (StreamWriter sw = new StreamWriter("ex4.txt"))
            {
                Console.WriteLine("Введите n:");
                int N = int.Parse(Console.ReadLine());
                Thread th1 = new Thread(() => PrintEvenNumbers(N, sw)); // четные
                Thread th2 = new Thread(() => PrintOddNumbers(N, sw));  // нечетные
                th1.Name = "EvenNumbers";
                th2.Name = "OddNumbers";
                th2.Priority = ThreadPriority.AboveNormal;
                th1.Start();
                th2.Start();
                th1.Join();
                th2.Join();
                Console.WriteLine("Работа потоков завершена");
            }

                //5
                int x = 14;
                TimerCallback tm = new TimerCallback(TimerPoints);
                System.Threading.Timer timer = new System.Threading.Timer(tm, x, 3000, 1000);
                Console.WriteLine("Таймер запущен. Нажмите Enter для завершения...");
                Console.ReadLine();
            

        }
        static void TimerPoints(object obj)
        {
            int x = (int)obj;
            Console.WriteLine($"{x}...");
        }
        static void PrintEvenNumbers(int n, StreamWriter sw)
        {
            lock (locker)   // входим в критическую секцию, блокируем locker
            {
                for(int i = 2; i <= n; i += 2)
                {
                    while (!isOdd)
                    {
                        Monitor.Wait(locker);   // выход из критической секции, освобождение объекта locker, он становится доступен для потоков
                    }
                    Console.WriteLine($"Четное: {i}");
                    sw.WriteLine($"Четное: {i}");
                    isEven = true;
                    isOdd = false;
                    Monitor.PulseAll(locker);   // уведомляет все потоки из очереди, что тек поток освободил obj, после чего один из потоков из очереди ожидания захватывает объект obj
                }
                workComplete = true;
                Monitor.PulseAll(locker);
            }
        }
        static void PrintOddNumbers(int n, StreamWriter sw)
        {
            lock (locker)   // входим в критическую секцию, блокируем locker
            {
                for (int i = 1; i <= n; i += 2)
                {
                    while (!isEven)
                    {
                        Monitor.Wait(locker);   // выход из критической секции, освобождение объекта locker, он становится доступен для потоков
                    }
                    Console.WriteLine($"Нечетное: {i}");
                    sw.WriteLine($"Нечетное: {i}");
                    isEven = false;
                    isOdd = true;
                    Monitor.PulseAll(locker);   // уведомляет все потоки из очереди, что тек поток освободил obj, после чего один из потоков из очереди ожидания захватывает объект obj
                }
                workComplete = true;
                Monitor.PulseAll(locker);
            }
        }
        static void Calculate(int n)
        {
            string fileName = "file.txt";
            using(StreamWriter  sw = new StreamWriter(fileName))
            {
                for(int i = 1; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.WriteLine(i);
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
    }
}