using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibraryLab10
{
    public class IdNumber
    {
        public int number;
        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Значение для поля number должно быть больше 0");
                }
                else
                    number = value;
            }
        }

        /// <summary>
        /// Конструтор с параметрами
        /// </summary>
        /// <param name="number"></param>
        public IdNumber(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Констркутор без параметров
        /// </summary>
        public IdNumber()
        {
            Number = 0;
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is IdNumber n)
                return this.Number == n.number;
            return false;
        }
    }

    public class MusicalInstrument: IInit, IComparable, ICloneable
    {
        public IdNumber id;

        protected string name;

        public string Name { get; set; }


        /// <summary>
        /// Констркутор без параметров
        /// </summary>
        public MusicalInstrument()
        {
            Name = "Музыкальный инструмент";
            id = new IdNumber(1);
        }
                       
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        public MusicalInstrument(string name, int number)
        {
            Name = name;
            id = new IdNumber(number);
        }

        /// <summary>
        /// Метод для пользовательского ввода значений
        /// </summary>
        public virtual void Init()
        {
            Console.WriteLine("Введите название музыкального инструмента: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите id инструмента: ");
            try
            {
                id.Number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Number = 0;
            }
        }

        /// <summary>
        /// Метод для заполнения рандомными значениями
        /// </summary>
        public virtual void IRandomInit()
        {
            string[] names = { "Гитара", "Электрогитара", "Фортепиано" };
            Random rnd = new Random();
            int index = rnd.Next(names.Length);
            Name = names[index];
            id.Number = rnd.Next(1, 100);
        }

        /// <summary>
        /// виртуальный метод печати
        /// </summary>
        public virtual void Print() 
        {
            Console.WriteLine($"id: {id}, Название: { Name }");
        }

        /// <summary>
        /// не виртуальнфй метод печати
        /// </summary>
        public void Show()
        {
            Console.WriteLine($"id: {id}, Название: { Name }");
        }

        public override string ToString()
        {
            return $"{id}: { Name },";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not MusicalInstrument) return false;
            return ((MusicalInstrument)obj).name == this.Name & ((MusicalInstrument)obj).id.Number == this.id.Number;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not MusicalInstrument) return -1;
            MusicalInstrument m = obj as MusicalInstrument;
            return System.String.Compare(this.Name, m.Name);
        }

        /// <summary>
        /// Создание глубокой копии объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new MusicalInstrument(Name, id.Number);
        }

        /// <summary>
        /// Поверхностное копирование объекта
        /// </summary>
        /// <returns></returns>
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
