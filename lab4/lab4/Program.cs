using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            TVProgpram tVProgpram1 = new TVProgpram("Телевизионная программа 1");
            Director tVProgpram2 = new TVProgpram("Телевизионная программа 2");
            ITurnOn tVProgpram3 = new TVProgpram("Телевизионная программа 3");

            if(tVProgpram1 is TVProgpram)
            {
                Console.WriteLine("tVProgram1 это телевизионная программа");
            }

            if (tVProgpram2 is TVProgpram)
            {
                Console.WriteLine("tVProgram2 это телевизионная программа");
            }

            if (tVProgpram3 is TVProgpram)
            {
                Console.WriteLine("tVProgram3 это телевизионная программа");
            }

            if((tVProgpram1 as  Director) != null)
            {
                Console.WriteLine("tVProgram1 это телевизионная программа определенного режиссера");
            }

            tVProgpram2.TurnOn();
            tVProgpram3.TurnOn();
            tVProgpram1.Watch();
            tVProgpram1.TurnOff();

            var tVProgram = new TVProgpram("Телевизионная программа 4");
            var movie = new Movie("Фильм 1");
            var news = new News("Новости 1");
            var featureFilm = new FeatureFilm("Художественный фильм 1");
            var cartoon = new Cartoon("Мультфильм 1");
            var advertising = new Advertising("Реклама 1");

            var DirectoryCinema = new Director[6];
            var printer = new Printer();

            DirectoryCinema[0] = tVProgram;
            DirectoryCinema[1] = movie;
            DirectoryCinema[2] = news;
            DirectoryCinema[3] = featureFilm;
            DirectoryCinema[4] = cartoon;
            DirectoryCinema[5] = advertising;

            foreach(var director in DirectoryCinema)
            {
                printer.IAmPrinting(director);
            }
        }
    }
}