using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6;

namespace lab6
{
    class ProgramException : Exception
    {
        //Класс в котором произошло исключение
        public string ErrorInClass { get; private set; }
        public ProgramException(string message, string errorInClass) : base(message)
        {
            ErrorInClass = errorInClass;
        }

        // Исключение для неверного жанра программы
        public class GenreException : ProgramException
        {
            public Genre InvalidGenre { get; private set; }

            public GenreException(string message, string errorInClass, Genre genre) : base(message, errorInClass)
            {
                InvalidGenre = genre;
            }
        }

        // Исключение для неверной продолжительности программы
        public class DurationException : ProgramException
        {
            public int InvalidDuration { get; private set; }

            public DurationException(string message, string errorInClass, int duration) : base(message, errorInClass)
            {
                InvalidDuration = duration;
            }
        }

        // Исключение для ошибки при создании программы с некорректным годом выпуска
        public class YearException : ProgramException
        {
            public int InvalidYear { get; private set; }

            public YearException(string message, string errorInClass, int year) : base(message, errorInClass)
            {
                InvalidYear = year;
            }
        }
    }
}
