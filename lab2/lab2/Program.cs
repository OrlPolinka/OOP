using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2;

namespace lab2
{
    partial class Phone
    {
        static void Main(string[] args)
        {
            Phone[] phones = new Phone[]
            {
                new Phone("Cherep", "Elizaveta", "Sergeevna", "Address1", "1234567812345678", 100.45, 52, 30.85, 96.52),
                new Phone("Valentik", "Polina", "Igorevna", "Address2", "7845659812326545", 64, 13.33, 85.6, 107),
                new Phone("Protas", "Kristina", "Ivanovna", "Address3", "4545656532981278", 52.6, 91.7, 10, 0)
            };

            Phone.CreateDefaultPhone(); //вызов закрытого конструктура
            phones[0].DisplayInfo();    //метод для вывода
            phones[1].DisplayInfo();    //метод для вывода
            phones[2].DisplayInfo();    //метод для вывода
            Phone.DisplayClassInfo();   //метод для вывода кол-ва объектов

            //использование методов Equals, ToString и GetHashCode
            Console.WriteLine("Сравнение объектов и методы класса Object:");
            Console.WriteLine($"Phone ToString: {phones[0].ToString()}");
            Console.WriteLine($"Phone 2 Equals Phone 3: {phones[1].Equals(phones[2])}");
            Console.WriteLine($"Phone 1 HashCode: {phones[0].GetHashCode()}");

            //обновление баланса 
            double newDebit = phones[0].Debit;
            double balanceOut;
            phones[0].UpdateBalance(ref newDebit, out balanceOut);
            Console.WriteLine($"Обновленный дебет для Phone 1: {newDebit}, новый баланс: {balanceOut}");

            //сведения об абонентах, у которых время внутригородских разговоров превышает заданное
            double cityTalkThreshold = 40;
            var cityTalkExceed = phones.Where(p => p.TimeCityTalk > cityTalkThreshold).ToArray();
            Console.WriteLine($"Абоненты с временем внутригородских разговоров больше {cityTalkThreshold} минут:");
            foreach(var phone in cityTalkExceed)
            {
                phone.DisplayInfo();
                Console.WriteLine();
            }

            //сведения об абонентах, которые пользовались междугородней связью
            var longDistanceUsers = phones.Where(p => p.TimeDistanceTalk > 0).ToArray();
            Console.WriteLine("Абоненты, которые пользовались междугородней связью:");
            foreach(var phone in longDistanceUsers)
            {
                phone.DisplayInfo();
                Console.WriteLine();
            }

            //анонимный тип
            var anonimousPhone = new
            {
                Surname = phones[0].Surname,
                Name = phones[0].Name,
                Balance = phones[0].CalculateBalance(),
                timeCityTalk = phones[0].TimeCityTalk
            };

        }
    }
}
