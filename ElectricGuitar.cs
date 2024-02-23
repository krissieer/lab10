using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class ElectricGuitar : Guitar
    {
        protected string powerSupply;

        public string PowerSupply { get; set; }

        /// <summary>
        /// конструктор без параметров
        /// </summary>
        public ElectricGuitar() : base()
        {
            PowerSupply = "USB";
            id = new IdNumber(1);
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stringsNumber"></param>
        /// <param name="powerSupply"></param>
        /// <param name="number"></param>
        public ElectricGuitar(string name, int stringsNumber, string powerSupply, int number) : base(name, stringsNumber, number)
        {
            PowerSupply = powerSupply;
        }


        /// <summary>
        /// метод для ввода значений с клавиатуры
        /// </summary>
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите источник питания: ");
            PowerSupply = Console.ReadLine();
        }

        /// <summary>
        /// метод для заполнения рандомными значениями
        /// </summary>
        public override void IRandomInit()
        {
            base.IRandomInit();
            Name = "Электрогитара";
            Random rnd = new Random();
            StringsNumber = rnd.Next(0, 15);
            string[] powerSupplies = { "Батарейки", "Аккумулятор", "Фиксированный источник питания", "USB" };
            int index = rnd.Next(powerSupplies.Length);
            PowerSupply = powerSupplies[index];
        }

        /// <summary>
        /// Виртуальный метод печати
        /// </summary>
        public override void Print()
        {
            Console.WriteLine($"id: {id}, Название: { Name }, Количество струн: { StringsNumber }, Источник питания: { PowerSupply }");
        }

        /// <summary>
        /// Не виртуальный метод печати
        /// </summary>
        public new void Show()
        {
            base.Show();
            Console.WriteLine($" Источник питания: {PowerSupply}");
        }

        public override string ToString()
        {
            return base.ToString() + $", работает на { PowerSupply }";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not ElectricGuitar) return false;
            return ((ElectricGuitar)obj).powerSupply == this.PowerSupply ;
        }
    }
}
