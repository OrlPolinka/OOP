using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab8;

namespace lab8
{
    public delegate void Upgrade();
    public delegate void Turn_on(int voltage);
    class Boss
    {
        public static event Turn_on Turn_on;
        public static event Turn_on Turn_off;
        public static event Upgrade OnUpgrade;

        public void UpgradeVersion()
        {
            Console.WriteLine("Обновление устройств");
            OnUpgrade?.Invoke();
        }

        public void TurnOnTech(int voltage)
        {
            Console.WriteLine($"Включение устройств с напряжением {voltage}V");
            Turn_on?.Invoke(voltage);
        }

        public void TurnOffTech(int voltage)
        {
            Console.WriteLine("Выключение устройств");
            Turn_off?.Invoke(voltage);
        }
    }
}
