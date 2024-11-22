using System;
using lab8;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss boss = new Boss();

            Technique tv = new Technique("Телевизор");
            Technique phone = new Technique("Телефон");
            Technique computer = new Technique("Компьютер");

            Boss.OnUpgrade += tv.OnUpgrade;
            Boss.OnUpgrade += phone.OnUpgrade;

            Boss.Turn_on += tv.Turn_on;
            Boss.Turn_on += computer.Turn_on;

            Boss.Turn_off += tv.Turn_off;
            Boss.Turn_off += phone.Turn_off;

            Console.WriteLine("Начальное состояние:");
            tv.Display();
            phone.Display();
            computer.Display();

            Console.WriteLine("Состояние после обновления версии:");
            boss.UpgradeVersion();
            tv.Display();
            phone.Display();
            computer.Display();

            Console.WriteLine("Включение техники с нормальным напряжением 200V:");
            boss.TurnOnTech(200);
            tv.Display();
            phone.Display();
            computer.Display();

            Console.WriteLine("Выключение техники:");
            boss.TurnOffTech(200);
            tv.Display();  
            phone.Display(); 
            computer.Display();

            Console.WriteLine("Включение техники с большим напряжением 360V:");
            boss.TurnOnTech(360);
            tv.Display();
            phone.Display();
            computer.Display();




            Console.WriteLine("\n\n\n");
            String.str = "Строка, для: проверки!   ...ПримЕр ИспольЗованиЯ;?  .";
            Action removePunctuation = String.RemovePunctuation;
            Action removeSpace = String.RemoveSpace;
            Action toUpperLetter = String.ToUpperLetter;
            Action toLowerLetter = String.ToLowerLetter;
            Func<string, string, string> addString = String.AddString;
            Predicate<string> containsExample = String.ContainsExample;

            removePunctuation();
            removeSpace();
            toUpperLetter();
            toLowerLetter();
            Console.WriteLine(addString(String.str, "!ДОБАВЛЕНИЕ строки!"));
            Console.WriteLine(containsExample(String.str));
        }
    }

}