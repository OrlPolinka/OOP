using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab10;

namespace lab10
{
    partial class Phone
    {
        private static int _nextId = 1; 
        private static int _objectCount = 0;    
        private const string phoneNumber = "375333265984";  

        public readonly int id; 

        private string surname;
        private string name;
        private string patronymic;
        private string address;
        private string creditCardNumber;
        private double debit;
        private double credit;
        private double timeCityTalk;    //в минутах
        private double timeDistanceTalk;    //в минутах

        public int Id
        {
            get { return id; }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой.");
                surname = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым.");
                name = value;
            }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Отчество не может быть пустым.");
                patronymic = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Адрес не может быть пустым.");
                address = value;
            }
        }
        public string CreditCardNumber
        {
            get { return creditCardNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер кредитной карты не может быть пустым.");
                creditCardNumber = value;
            }
        }
        public double Debit
        {
            get { return debit; }
            set { debit = value; }
        }
        public double Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public double TimeCityTalk
        {
            get { return timeCityTalk; }
            set { timeCityTalk = value; }
        }
        public double TimeDistanceTalk
        {
            get { return timeDistanceTalk; }
            set { timeCityTalk = value; }
        }

        //статический конструктор
        static Phone()
        {
            _objectCount = 0;
        }
        public Phone()
        {
            id = _nextId++;
            surname = "Default";
            name = "Default";
            patronymic = "Default";
            address = "Default";
            creditCardNumber = "Default";
            debit = 0;
            credit = 0;
            timeCityTalk = 0;
            timeDistanceTalk = 0;
            _objectCount++;
        }

        public Phone(string cSurname, string cName, string cPatronymic, string cAddress, string cCreditCardNumber, double cDebit, double cCredit, double cTimeCityTalk, double cTimeDistanceTalk)
        {
            id = _nextId++;
            surname = cSurname ?? "Unknown";
            name = cName ?? "Unknown";
            patronymic = cPatronymic ?? "Unknown";
            address = cAddress ?? "Unknown";
            creditCardNumber = cCreditCardNumber ?? "Unknown";
            debit = cDebit;
            credit = cCredit;
            timeCityTalk = cTimeCityTalk;
            timeDistanceTalk = cTimeDistanceTalk;
            _objectCount++;
        }

        public Phone(string cSurname, string cName, string cPatronymic, string cAddress, string cCreditCardNumber, double cTimeCityTalk, double cTimeDistanceTalk)
        {
            id = _nextId++;
            surname = cSurname ?? "Unknown";
            name = cName ?? "Unknown";
            patronymic = cPatronymic ?? "Unknown";
            address = cAddress ?? "Unknown";
            creditCardNumber = cCreditCardNumber ?? "Unknown";
            debit = 52.5;
            credit = 73;
            timeCityTalk = cTimeCityTalk;
            timeDistanceTalk = cTimeDistanceTalk;
            _objectCount++;
        }

        //метод для расчета баланса
        public double CalculateBalance()
        {
            return debit - credit;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Отчество: {patronymic}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Номер кредитной карточки: {creditCardNumber}");
            Console.WriteLine($"Дебет: {debit}");
            Console.WriteLine($"Кредит: {credit}");
            Console.WriteLine($"Время городских разговоров: {timeCityTalk}");
            Console.WriteLine($"Время междугородних разговоров: {timeDistanceTalk}");
        }

        //метод с использованием ref и out
        public void UpdateBalance(ref double debitRef, out double balanceOut)
        {
            debitRef += 10;
            balanceOut = debitRef - credit;
        }

        public override string ToString()
        {
            return $"ID: {id}, Фамилия: {surname}, Имя: {name}, Отчество: {patronymic}, Адрес: {address}, Номер кредитной карточки: {creditCardNumber}, Дебет: {debit}," +
                $"Кредит: {credit}, Время городских разговоров: {timeCityTalk}, Время междугородних разговоров: {timeDistanceTalk}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Phone)) return false;
            Phone phone = (Phone)obj;
            return surname == phone.surname && name == phone.name && patronymic == phone.patronymic && address == phone.address
                && creditCardNumber == phone.creditCardNumber && debit == phone.debit && credit == phone.credit && timeCityTalk == phone.timeCityTalk
                && timeDistanceTalk == phone.timeDistanceTalk;
        }

        public override int GetHashCode()
        {
            return (surname?.GetHashCode() ?? 0) ^ (name?.GetHashCode() ?? 0) ^ (patronymic?.GetHashCode() ?? 0) ^ (address?.GetHashCode() ?? 0);
        }

        public static void DisplayClassInfo()
        {
            Console.WriteLine($"В классе Phone создано {_objectCount} объектов.");
        }
    }
}
