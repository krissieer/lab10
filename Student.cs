using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class Student: IInit
    {
        protected int age;
        protected double gpa;

        public string Name { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0 || value > 100)
                {
                    throw new Exception("Ошибка! Значение для поля age не должно быть меньше  0 или больше 100");
                }
                else
                    age = value;
            }
        }

        public double Gpa
        {
            get => gpa;
            set
            {
                if (value > 10 || value < 0)
                {
                    throw new Exception("Ошибка! Значение для поля gpa должно быть в промежутке от 0 до 10");
                }
                else
                    gpa = value;
            }
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, gpa: {Gpa.ToString("0.0")}";
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Student()
        {
            Name = "NoName";
            Age = 20;
            Gpa = 5.5;        
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gpa"></param>
        public Student(string name, int age, double gpa)
        {
            this.Name = name;
            this.Age = age;
            this.Gpa = gpa;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="person"></param>
        public Student(Student person)
        {
            Name = person.Name;
            Age = person.Age;
            Gpa = person.Gpa;
        }

        /// <summary>
        /// Метод для пользовательсконо ввода значений
        /// </summary>
        public virtual void Init()
        {
            Console.WriteLine("Введите имя студента: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите возраст студента: ");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите Gpa студента: ");
            Gpa = double.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Метод для заполнения значений рандомно
        /// </summary>
        public virtual void IRandomInit()
        {
            Random rnd = new Random();
            string[] studentNames = { "Bob", "John", "Clark", "Tom", "Jen", "Lexa", "Sarah", "Ben", "Shown" };
            int randonIndex = rnd.Next(studentNames.Length);
            Name = studentNames[randonIndex];
            Age = rnd.Next(18, 21);
            Gpa = rnd.NextDouble() + rnd.Next(0, 9);           
        }

        /// <summary>
        /// Вывод информации о студенте
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Имя - {Name}, Возраст - {Age}, Балл - {Gpa.ToString("0.0")}");
            Console.WriteLine();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Student) return false;
            return ((Student)obj).age == this.Age && ((Student)obj).gpa == this.Gpa;
        }
    }
}
