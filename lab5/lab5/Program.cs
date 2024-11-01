using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using lab5;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramContainer container = new ProgramContainer();
            ProgramController controller = new ProgramController(container);
            Printer printer = new Printer();

            var tVProgram = new TVProgram("Телевизионная программа 1", Genre.Documentary, 30, 2020);
            var movie1 = new Movie("Фильм 1", Genre.Drama, 120, 2021);
            var movie2 = new Movie("Фильм 2", Genre.Comedy, 80, 2022);
            var movie3 = new Movie("Фильм 3", Genre.Action, 150, 2015);
            var movie4 = new Movie("Фильм 4", Genre.Documentary, 100, 2022);
            var news = new News("Новости 1", Genre.News, 20, 2019);
            var featureFilm = new FeatureFilm("Художественный фильм 1", Genre.Action, 90, 2022);
            var cartoon = new Cartoon("Мультфильм 1", Genre.Cartoon, 15, 2012);
            var advertising = new Advertising("Реклама 1", Genre.Advertising, 5, 2022);

            controller.AddProgram(tVProgram);
            controller.AddProgram(movie1);
            controller.AddProgram(movie2);
            controller.AddProgram(movie3);
            controller.AddProgram(movie4);
            controller.AddProgram(news);
            controller.AddProgram(featureFilm);
            controller.AddProgram(cartoon);
            controller.AddProgram(advertising);

            // Печать всех программ
            controller.ShowAllPrograms();

            Console.WriteLine("\n");

            // Печать фильмов по году
            controller.ShowMoviesFromYear(2022);

            Console.WriteLine("\n");

            // Подсчёт продолжительности всех программ
            controller.ShowTotalDuration();

            // Подсчёт реклам
            controller.ShowNumberOfAdvertisements();

            Console.WriteLine("\n");

            // Используем Printer
            foreach (var program in new Director[] { tVProgram, movie1, movie2, movie3, movie4, news, featureFilm, cartoon, advertising })
            {
                printer.IAmPrinting(program);
            }
        }
    }

}