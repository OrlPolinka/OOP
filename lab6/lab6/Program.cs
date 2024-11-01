using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using lab6;
using static lab6.ProgramException;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPrograms = 3;
            System.Diagnostics.Debug.Assert(totalPrograms > 0, "Количество программ должно быть больше нуля для расчёта среднего значения.");


            try
            {
                try
                {
                    var movie = new Movie("Фильм", Genre.Comedy, 120, 2021); 
                    throw new ProgramException.GenreException("Произошла ошибка в жанре.", nameof(Movie), Genre.Action);

                }
                catch (ProgramException ex)
                {
                    Console.WriteLine($"Отловлено DirectorException: {ex.Message}");
                    throw;  // Проброс исключения для обработки выше
                }
            }
            catch (ProgramException ex)
            {
                Console.WriteLine($"Повторно отловлено DirectorException на более высоком уровне: {ex.Message}");
            }




            try
            {
                int totalProgram = 0;
                int averageDuration = 120 / totalProgram;  // Деление на ноль
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка деление на ноль: {ex.Message}");
            }

            try
            {
                string filePath = "nonexistentfile.txt";
                string content = File.ReadAllText(filePath);  // Ошибка раьоты с файлами
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка работы с файлами: {ex.Message}");
            }

            try
            {
                var movie1 = new Movie("Фильм 1", (Genre)100, 120, 2021); // Некорректный жанр
            }
            catch (GenreException ex)
            {
                Console.WriteLine($"Ошибка жанра: {ex.Message} в классе {ex.ErrorInClass}. Некорректный жанр: {ex.InvalidGenre}");
            }

            try
            {
                var movie2 = new Movie("Фильм 2", Genre.Comedy, -10, 2022); // Некорректная длительность
            }
            catch (DurationException ex)
            {
                Console.WriteLine($"Ошибка продолжительности: {ex.Message} в классе {ex.ErrorInClass}. Неверная продолжительность: {ex.InvalidDuration}");
            }

            try
            {
                var movie3 = new Movie("Фильм 3", Genre.Action, 120, 2025); // Некорректный год
            }
            catch (YearException ex)
            {
                Console.WriteLine($"Ошибка года: {ex.Message} в классе {ex.ErrorInClass}. Неверный год: {ex.InvalidYear}");
            }


            // Универсальный обработчик исключений
            catch (ProgramException ex)
            {
                Console.WriteLine($"Общее исключение: произошла ошибка в {ex.ErrorInClass}: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Очистка ресурсов выполнена.");
            }


        }
    }

}