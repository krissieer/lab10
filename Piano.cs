using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class Piano : MusicalInstrument
    {
        protected string keyLayout;
        public string KeyLayout { get; set; }

        protected int keysNumber;
        public int KeysNumber
        {
            get => keysNumber;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Значение для поля keysNumber должно быть больше 0");
                }
                else
                    keysNumber = value;
            }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Piano() : base()
        {
            KeyLayout = "октавная";
            KeysNumber = 88;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="keyLayout"></param>
        /// <param name="keysNumber"></param>
        /// <param name="number"></param>
        public Piano(string name, string keyLayout, int keysNumber, int number) : base(name, number)
        {
            KeyLayout = keyLayout;
            KeysNumber = keysNumber;
        }

        /// <summary>
        /// метод для ввода значений с клавиатуры
        /// </summary>
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество клавиш: ");
            KeysNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите вид раскладки клавиш: ");
            KeyLayout = Console.ReadLine();
        }

        /// <summary>
        /// метод для заполнения рандомными значениями
        /// </summary>
        public override void IRandomInit()
        {
            base.IRandomInit();  
            Name = "Фортепиано";
            Random rnd = new Random();
            KeysNumber = rnd.Next(0, 100);
            string[] keyLayouts = { "Октавная", "Шкальная", "Дигитальная" };
            int index = rnd.Next(keyLayouts.Length);
            KeyLayout = keyLayouts[index];
        }

        /// <summary>
        /// Виртуальный метод печати
        /// </summary>
        public override void Print()
        {
            Console.WriteLine($"id: {id}, Название: { Name }, Раскладка клавиш: { KeyLayout }, количество клавиш: { KeysNumber }");
        }

        /// <summary>
        /// не виртуальный метод для печати
        /// </summary>
        public new void Show()
        {
            base.Show();
            Console.WriteLine($" Раскладка клавиш: {KeyLayout}, количество клавиш: {KeysNumber}");
        }

        public override string ToString()
        {
            return base.ToString() + $" { KeyLayout } раскладка, { KeysNumber } клавиш";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Piano) return false;
            return ((Piano)obj).keyLayout == this.KeyLayout & ((Piano)obj).keysNumber == this.KeysNumber;
        }
    }
}
