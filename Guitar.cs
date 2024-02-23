using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class Guitar : MusicalInstrument
    {
        protected int stringsNumber;

        public int StringsNumber
        {
            get => stringsNumber;
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new Exception("Ошибка! Значение для поля stringsNumber должно быть в промежутке от 0 до 20");
                }
                else
                    stringsNumber = value;
            }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Guitar() : base()
        {
            StringsNumber = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stringsNumber"></param>
        /// <param name="number"></param>
        public Guitar(string name, int stringsNumber, int number) : base(name, number)
        {
            StringsNumber = stringsNumber;
        }

        /// <summary>
        /// Метод для пользовательского ввода значений
        /// </summary>
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество струн: ");
            try
            {
                StringsNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                StringsNumber = 0;
            };
        }

        /// <summary>
        /// Метод для зполнения рандомными значениями
        /// </summary>
        public override void IRandomInit()
        {
            base.IRandomInit();
            Name = "Гитара";
            Random rnd = new Random();
            StringsNumber = rnd.Next(0, 10);
        }

        /// <summary>
        /// Виртуальный метод печати
        /// </summary>
        public override void Print()
        {
            Console.WriteLine($"id: {id}, Название: { Name }, Количество струн: { StringsNumber }");
        }

        /// <summary>
        /// Не виртуальный метод печати
        /// </summary>
        public new void Show()
        {
            base.Show();
            Console.WriteLine($" Количество струн: {StringsNumber}");
        }

        public override string ToString()
        {
            return base.ToString() + $" { StringsNumber } струн";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Guitar) return false;
            return ((Guitar)obj).stringsNumber == this.StringsNumber;
        }
    }
}
