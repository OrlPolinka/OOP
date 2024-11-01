using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6;
using static lab6.ProgramException;

namespace lab6
{
    //перечисление
    public enum Genre
    {
        Drama,
        Comedy,
        Action,
        Documentary,
        News,
        Cartoon,
        Advertising
    }

    //структура
    public struct ProgramDetails
    {
        public string Title { get; set; }
        public Genre ProgramGenre { get; set; }
        public int DurationMinutes { get; set; }
        public int ReleaseYear { get; set; }

        public ProgramDetails(string title, Genre genre, int duration, int releaseYear)
        {
            Title = title;
            ProgramGenre = genre;
            DurationMinutes = duration;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Жанр: {ProgramGenre}, Продолжительность: {DurationMinutes} минут, Год выпуска: {ReleaseYear}";
        }
    }

    interface ITurnOn
    {
        void Watch();
        void TurnOn();
    }

    public abstract class Director
    {
        public string Name { get; set; }

        public virtual void TurnOff()
        {
            Console.WriteLine("Выключен кинематогроф режиссера");
        }

        public abstract void TurnOn();
    }

    //телевизионная программа
    //partial-класс
    public partial class TVProgram : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public TVProgram(string name, Genre genre, int duration, int releaseYear)
        {
            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключена телевизионная программа");
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    //фильм
    public class Movie : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public Movie(string name, Genre genre, int duration, int releaseYear)
        {
            // Проверка жанра
            if (!Enum.IsDefined(typeof(Genre), genre))
            {
                throw new GenreException("Некорректный жанр фильма.", nameof(Movie), genre);
            }

            // Проверка длительности
            if (duration <= 0)
            {
                throw new DurationException("Продолжительность фильма не может быть отрицательной или равной нулю.", nameof(Movie), duration);
            }

            // Проверка года выпуска
            if (releaseYear > DateTime.Now.Year)
            {
                throw new YearException("Год выпуска не может быть больше текущего года.", nameof(Movie), releaseYear);
            }

            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключен фильм");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите фильм");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили фильм");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включен фильм");
        }
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    //новости
    public class News : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public News(string name, Genre genre, int duration, int releaseYear)
        {
            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключены новости");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите новости");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили новости");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включены новости");
        }
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    //художественный фильм
    public class FeatureFilm : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public FeatureFilm(string name, Genre genre, int duration, int releaseYear)
        {
            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключен художественный фильм");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите художественный фильм");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили художественный фильм");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включен художественный фильм");
        }
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    //sealed-класс(запечатанный) мультфильм
    public sealed class Cartoon : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public Cartoon(string name, Genre genre, int duration, int releaseYear)
        {
            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключен мультфильм");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите мультфильм");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили мультфильм");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включен мультфильм");
        }
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    //реклама
    public class Advertising : Director, ITurnOn
    {
        public ProgramDetails Details { get; set; }

        public Advertising(string name, Genre genre, int duration, int releaseYear)
        {
            Name = name;
            Details = new ProgramDetails(name, genre, duration, releaseYear);
        }

        public override void TurnOff()
        {
            Console.WriteLine("Выключена реклама");
        }

        public void Watch()
        {
            Console.WriteLine("Вы смотрите рекламу");
        }

        public override void TurnOn()
        {
            Console.WriteLine("Вы включили рекламу");
        }

        void ITurnOn.TurnOn()
        {
            Console.WriteLine("Включена реклама");
        }
        public override string ToString()
        {
            return Details.ToString();
        }
    }

    //класс-контейнер
    public class ProgramContainer
    {
        private List<Director> programList = new List<Director>();

        public void AddProgram(Director program)
        {
            programList.Add(program);
        }

        public void RemoveProgram(Director program)
        {
            programList.Remove(program);
        }

        public void DisplayPrograms()
        {
            foreach (var program in programList)
            {
                Console.WriteLine(program);
            }
        }

        public List<Movie> FindMoviesByYear(int year)
        {
            return programList.OfType<Movie>().Where(m => m.Details.ReleaseYear == year).ToList();
        }

        public int CountAdvertisements()
        {
            return programList.OfType<Advertising>().Count();
        }

        public int CalculateTotalDuration()
        {
            return programList.Sum(p => p.GetType().GetProperty("Details").GetValue(p) is ProgramDetails details ? details.DurationMinutes : 0);
        }
    }

    //класс-контролер
    public class ProgramController
    {
        private ProgramContainer container;

        public ProgramController(ProgramContainer container)
        {
            this.container = container;
        }

        public void AddProgram(Director program)
        {
            container.AddProgram(program);
        }

        public void RemoveProgram(Director program)
        {
            container.RemoveProgram(program);
        }

        public void ShowAllPrograms()
        {
            container.DisplayPrograms();
        }

        public void ShowMoviesFromYear(int year)
        {
            var movies = container.FindMoviesByYear(year);
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        public void ShowTotalDuration()
        {
            int totalDuration = container.CalculateTotalDuration();
            Console.WriteLine($"Общая продолжительность всех программ: {totalDuration} минут");
        }

        public void ShowNumberOfAdvertisements()
        {
            int adCount = container.CountAdvertisements();
            Console.WriteLine($"Количество рекламных роликов: {adCount}");
        }
    }

}
