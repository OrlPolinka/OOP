using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab16;

namespace lab16
{
    public class Driver
    {
        public int AgeOfDrive;
        public string DriverName;
        public int MaxWeightOfCargo;
        public bool CarCondition;
        public int YearOfIssue;

        public Driver(int ageOfDrive, string driverName, int maxWeightOfCargo, bool carCondition, int yearOfIssue)
        {
            AgeOfDrive = ageOfDrive;
            DriverName = driverName;
            MaxWeightOfCargo = maxWeightOfCargo;
            CarCondition = carCondition;
            YearOfIssue = yearOfIssue;
        }
        public override string ToString()
        {
            return $"Имя водителя: {DriverName}\nСтаж работы: {AgeOfDrive} лет\nХарактеристики автомобиля:\nМаксимальный вес груза: {MaxWeightOfCargo}кг\nГод выпуска: {YearOfIssue} год\nСостояние автомобиля: {CarCondition}";
        }
    }
}
