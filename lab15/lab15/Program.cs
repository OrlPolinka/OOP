using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using lab15;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            int[][] matrix1 = {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 }
            };
            int[][] matrix2 = {
                new int[] { 7, 8 },
                new int[] { 9, 10 },
                new int[] { 11, 12 }
            };
            const int numberOfRuns = 10; // Количество прогона задачи
            long totalElapsedTime = 0; // Общее время выполнения

            for (int i = 0; i < numberOfRuns; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew(); // запуск таймера
                Task<int[][]> task = Task.Run(() => MatrixMultiplication(matrix1, matrix2));
                Console.WriteLine($"ID задачи: {task.Id}");
                Console.WriteLine($"Была ли задача выполнена?\t{task.IsCompleted}");
                Console.WriteLine($"Статус задачи: {task.Status}");
                task.Wait();    // ожидание выполнения
                int[][] result = task.Result;
                Console.WriteLine("Итоговая матрица:");
                foreach (var row in result)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
                stopwatch.Stop();   // остановка таймера
                totalElapsedTime += stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"Прогон {i + 1}: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine();
            }
            double averageTime = totalElapsedTime/(double)numberOfRuns; ;
            Console.WriteLine($"Среднее время выполнения: {averageTime}");
            Console.WriteLine();
            
            
            //2
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            try {
                Task<int[][]> task2 = Task.Run(() => MatrixMultiplication2(matrix1, matrix2, token), token);
                cts.Cancel();
                task2.Wait(token);    // ожидание выполнения
                int[][] result2 = task2.Result;
                Console.WriteLine("Итоговая матрица:");
                foreach (var row in result2)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Задача была отменена");
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    if (inner is OperationCanceledException)
                        Console.WriteLine("Задача была отменена.");
                    else
                        Console.WriteLine($"Ошибка: {inner.Message}");
                }
            }
            finally
            {
                Console.WriteLine("Статус задача: отменена");
                cts.Dispose();
            }
            Console.WriteLine();


            //3
            Task<int> taskA = Task.Run(() => CalculateA());
            Task<int> taskB = Task.Run(() => CalculateB());
            Task<int> taskC = Task.Run(() => CalculateC());
            Task<int> finalTask = Task.Factory.ContinueWhenAll(
                new[] {taskA, taskB, taskC},
                tasks=>
                {
                    int a = tasks[0].Result;
                    int b = tasks[1].Result;
                    int c = tasks[2].Result;

                    Console.WriteLine($"A = {a}, B = {b}, C = {c}");
                    return a + b + c;
                }
                );
            finalTask.Wait();
            Console.WriteLine($"Результат: {finalTask.Result}");
            Console.WriteLine();


            //4.1
            Task<int> task4 = taskA.ContinueWith(t => { 
                int x = t.Result;
                return x;
            });
            Console.WriteLine(task4.Result + "\n");

            //4.2, 8
            Task<int> task4_2 = Task.Run(() => Enumerable.Range(1, 1000).Count(n => (n % 2 == 0)));
            Console.WriteLine($"Результат: {task4_2.Result}");
            Task<string> task4_3 = Task.Run(async () =>
            {
                int result = await task4_2;
                return $"Продолжение: {result * 2}";
            });
            Console.WriteLine(task4_3.GetAwaiter().GetResult() + "\n");


            //5
            int arraySize = 1000000;
            int numArrays = 5;
            int[][] Arr = new int[arraySize][];
            Parallel.For(0, numArrays, i =>
            {
                Random rand = new Random();
                Arr[i] = new int[arraySize];
                for (int j = 0; j < arraySize; j++)
                {
                    Arr[i][j] = rand.Next(0, 100);
                }
                Console.WriteLine($"Массив {i + 1} сгенерирован");
            });
            Console.WriteLine();

            string[] texts = {
                "Текст для примера.",
                "Класс Parallel.",
                "Язык программирования C#."
            };

            Parallel.ForEach(texts, text =>
            {
                string updateText = text.Replace("C#", "F#").Replace("примера", "обработки");
                Console.WriteLine($"Обработанный текст: {updateText}");
            });
            Console.WriteLine();


            //6
            Parallel.Invoke(
                () => Console.WriteLine($"Выполняется задача: {Task.CurrentId}"),
                () => Console.WriteLine(CalculateB()),
                () => Console.WriteLine(CalculateC()),
                () => Console.WriteLine($"Выполняется задача: {Task.CurrentId}")
            );
            Console.WriteLine();


            //7
            BlockingCollection<string> blockcoll = new BlockingCollection<string>();
            Task[] supplier = new Task[5];
            Task[] buyer = new Task[10];

            for(int i = 0; i < buyer.Length; i++)
            {
                int buyerId = i;
                buyer[i] = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        blockcoll.Add(GetProductByIndex(buyerId));
                    }
                });
            }
            for(int i = 0;i<supplier.Length;i++)
            {
                supplier[i] = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(GetSupplierSleepTime(i));
                        blockcoll.Take();
                    }
                });
            }
            int count = 1;
            //Task monitoringTask = Task.Run(() =>
            //{
                while (true)
                {
                    if (blockcoll.Count != count && blockcoll.Count != 0)
                    {
                        count = blockcoll.Count;
                        Thread.Sleep(500);
                        Console.WriteLine("Обновление склада:");
                        foreach (var item in blockcoll)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            //});
            
        }
        static string GetProductByIndex(int index)
        {
            string[] products = { "Стол", "Стул", "Шкаф", "Кровать", "Лампа", "Диван", "Комод", "Кресло", "Компьютер", "Холодильник" };
            return products[index];
        }
        static int GetSupplierSleepTime(int index)
        {
            int[] sleepTimes = { 300, 500, 700, 1000 };
            return sleepTimes[index];
        }
        static int CalculateA()
        {
            return 5;
        }
        static int CalculateB()
        {
            return 10;
        }
        static int CalculateC()
        {
            return 15;
        }
        static int[][] MatrixMultiplication2(int[][] matrix1, int[][] matrix2, CancellationToken token)
        {
            int rows1 = matrix1.Length;
            int cols1 = matrix1[0].Length;
            int rows2 = matrix2.Length;
            int cols2 = matrix2[0].Length;

            if (cols1 != rows2)
            {
                throw new InvalidOperationException("Количество столбцов первой матрицы должно быть равно количеству строк второв матрицы");
            }

            int[][] result = new int[rows1][];
            for (int i = 0; i < rows1; i++)
            {
                result[i] = new int[cols2];
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    token.ThrowIfCancellationRequested(); // Проверка токена
                    result[i][j] = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        token.ThrowIfCancellationRequested(); // Проверка токена
                        result[i][j] += matrix1[i][k] * matrix2[k][j];
                    }
                }
            }
            return result;
        }
        static int[][] MatrixMultiplication(int[][] matrix1, int[][] matrix2)
        {
            int rows1=matrix1.Length;
            int cols1 = matrix1[0].Length;
            int rows2 = matrix2.Length;
            int cols2 = matrix2[0].Length;

            if (cols1 != rows2)
            {
                throw new InvalidOperationException("Количество столбцов первой матрицы должно быть равно количеству строк второв матрицы");
            }

            int[][] result = new int[rows1][];
            for(int i = 0; i < rows1; i++)
            {
                result[i] = new int[cols2];
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j =0; j < cols2; j++)
                {
                    result[i][j] = 0;
                    for(int k = 0; k < cols1; k++)
                    {
                        result[i][j] += matrix1[i][k] * matrix2[k][j];
                    }
                }
            }
            return result;
        }
    }
}