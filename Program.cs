using ClassLibraryLab10;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace lab_____10
{
    internal class Program
    {
        /// <summary>
        /// Среднее количество струн всех гитар
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static double GetAvarageStringsNumber(MusicalInstrument[] arr)
        {
            double sum = 0;
            double count = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (item is Guitar g)
                {
                    sum += g.StringsNumber;
                    count++;
                }                   
            }
            return sum / count;
        }

        /// <summary>
        /// Количество струн всех электрогитар c фиксированным источником питания
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int GetStringsNumberSum(MusicalInstrument[] arr)
        {
            int sum = 0;
            foreach (MusicalInstrument item in arr)
            {
                ElectricGuitar e = item as ElectricGuitar;
                if ((e != null) && (e.PowerSupply == "Фиксированный источник питания"))
                {
                    sum += e.StringsNumber;
                }
            }
            return sum;
        }

        /// <summary>
        /// Максимальное количество клавиш на фортепиано с октавной раскладко
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int GetMaxKeysNumber(MusicalInstrument[] arr)
        {
            int max = 0;
            foreach (MusicalInstrument item in arr)
            {
                if (typeof(Piano) == item.GetType())
                {
                    Piano p = item as Piano;
                    if (p.KeyLayout == "Октавная")
                    {
                        if (p.KeysNumber > max)
                            max = p.KeysNumber;
                    }
                }    
            }
            return max;
        }

        /// <summary>
        /// Печать массива из элементов созданной иерархии
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(MusicalInstrument[] array)
        {
            foreach (MusicalInstrument item in array)
            {
                item.Print();
            }
        }

        /// <summary>
        /// Печать массива из элементов созданной иерархии + класс Student
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray2(IInit[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            int answer;
            bool isConvertAns;

            Random rnd = new Random();
            MusicalInstrument[] array = new MusicalInstrument[20]; // массив из элементов классов иерерхии 

            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = rnd.Next(4);

                if (randomIndex == 0)
                {
                    MusicalInstrument m1 = new MusicalInstrument();
                    m1.IRandomInit();
                    array[i] = m1;
                }
                else if (randomIndex == 1)
                {
                    Guitar g1 = new Guitar();
                    g1.IRandomInit();
                    array[i] = g1;
                }
                else if (randomIndex == 2)
                {
                    ElectricGuitar e1 = new ElectricGuitar();
                    e1.IRandomInit();
                    array[i] = e1;
                }
                else if (randomIndex == 3)
                {
                    Piano p1 = new Piano();
                    p1.IRandomInit();
                    array[i] = p1;
                }
            }

            // счетчики количества созданных объектов каждого класса
            int countMusical = 0;
            int countGuitar = 0;
            int countElectricGuitar = 0;
            int countPiano = 0;
            int countStudent = 0;

            IInit[] array2 = new IInit[30]; // массив из элементов классов иерерхии + класс Student
            for (int i = 0; i < array2.Length; i++)
            {
                int randomIndex = rnd.Next(5);

                if (randomIndex == 0)
                {
                    array2[i] = new MusicalInstrument();
                    array2[i].IRandomInit();
                    countMusical++;
                }
                else if (randomIndex == 1)
                {
                    array2[i] = new Guitar();
                    array2[i].IRandomInit();
                    countGuitar++;
                }
                else if (randomIndex == 2)
                {
                    array2[i] = new ElectricGuitar();
                    array2[i].IRandomInit();
                    countElectricGuitar++;
                }
                else if (randomIndex == 3)
                {
                    array2[i] = new Piano();
                    array2[i].IRandomInit();
                    countPiano++;
                }
                else if (randomIndex == 4)
                {
                    array2[i] = new Student();
                    array2[i].IRandomInit();
                    countStudent++;
                }
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Работа с массивом, состоящим из объектов классов иерархии");               
                Console.WriteLine("2. Работа с массивом, состоящим из объектов классов иерархии и класса Student");
                Console.WriteLine("3. Поверхстное и глубое копирование объекта");
                Console.WriteLine("4. Закончить работу");
                Console.WriteLine();

                do
                {
                    isConvertAns = int.TryParse(Console.ReadLine(), out answer);
                    if (!isConvertAns)
                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                } while (!isConvertAns);

                switch (answer)
                {
                    case 1: // Работа с массивом, состоящим из объектов классов иерархии
                        {
                            int ans;
                            bool isConvert;
                            Console.WriteLine(" ==== ИСХОДНЫЙ МАССИВ СФОРМИРОВАН === ");
                            PrintArray(array);

                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("1. Сортировка массива");
                                Console.WriteLine("2. Бинарный поиск в отсортированном массиве");
                                Console.WriteLine("3. Запросы");
                                Console.WriteLine("4. Печать массива");
                                Console.WriteLine("5. Назад");
                                Console.WriteLine();

                                do
                                {
                                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                                    if (!isConvert)
                                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                } while (!isConvert);

                                switch (ans)
                                {
                                    case 1: // Сортировка массива
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("1. Сортировка массива по названию инструмента");
                                            Console.WriteLine("2. Сортировка массива по id номеру");
                                            Console.WriteLine();

                                            do
                                            {
                                                isConvert = int.TryParse(Console.ReadLine(), out ans);
                                                if (!isConvert)
                                                    Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                            } while (!isConvert);

                                            switch (ans)
                                            {
                                                case 1: // Сортировка массива по названию инструмента
                                                    {
                                                        Array.Sort(array);
                                                        Console.WriteLine("МАССИВ ОТСОРТИРОВАН ПО НАЗВАНИЮ");
                                                        break;
                                                    }
                                                case 2: // Сортировка массива по длине названия инструмента
                                                    {
                                                        Array.Sort(array, new SortByIdNumber());
                                                        Console.WriteLine("МАССИВ ОТСОРТИРОВАН ПО ID НОМЕРУ");
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 2: // Бинарный поиск в отсортированном массиве
                                        {
                                            MusicalInstrument m = new MusicalInstrument();
                                            m.Init();
                                            array[2] = m;
                                            Console.WriteLine($"== Массив с добавленным элементом ({m}) ==");
                                            PrintArray(array);
                                            Console.WriteLine();
                                            Array.Sort(array);
                                            Console.WriteLine("== Отсортированный по названию массив с добавленным элементом ==");
                                            PrintArray(array);
                                            Console.WriteLine();
                                           
                                            int position = Array.BinarySearch(array, m);
                                            if (position < 0)
                                                Console.WriteLine("Нет такого элемента");
                                            else
                                                Console.WriteLine($"Элемент {m} находится на {position + 1} месте");
                                            break;
                                        }
                                    case 3: // Запросы
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("1. Среднее количество струн всех гитар");
                                            Console.WriteLine("2. Количество струн всех электрогитар c фиксированным источником питания");
                                            Console.WriteLine("3. Максимальное количество клавиш на фортепиано с октавной раскладкой");
                                            Console.WriteLine();

                                            do
                                            {
                                                isConvert = int.TryParse(Console.ReadLine(), out ans);
                                                if (!isConvert)
                                                    Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                            } while (!isConvert);

                                            switch (ans)
                                            {
                                                case 1: // Среднее количество струн всех гитар
                                                    {
                                                        double avarageStringsNumber = GetAvarageStringsNumber(array);
                                                        Console.WriteLine($"Среднее количество струн всех гитар: {avarageStringsNumber.ToString("0.00")}");
                                                        break;
                                                    }
                                                case 2: // Количество струн всех электрогитар c фиксированным источником питания
                                                    {
                                                        int stringsNumberSum = GetStringsNumberSum(array);
                                                        Console.WriteLine($"Количество струн всех электрогитар c фиксированным источником питания: {stringsNumberSum}");
                                                        break;
                                                    }
                                                case 3: // Максимальное количество клавиш на фортепиано с октавной раскладкой
                                                    {
                                                        int maxKeysNumber = GetMaxKeysNumber(array);
                                                        Console.WriteLine($"Максимальное количество клавиш на фортепиано с октавной раскладкой: {maxKeysNumber}");
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 4: // Печать массива
                                        {
                                            Console.WriteLine("1. Печать массива с помощью виртуальной функции");
                                            Console.WriteLine("2. Печать массива с помощью обычной функции");
                                            Console.WriteLine();

                                            do
                                            {
                                                isConvert = int.TryParse(Console.ReadLine(), out ans);
                                                if (!isConvert)
                                                    Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                            } while (!isConvert);

                                            switch (ans)
                                            {
                                                case 1: // Печать массива с помощью виртуальной функции
                                                    {
                                                        PrintArray(array);
                                                        break;
                                                    }
                                                case 2: // Печать массива с помощью обычной функции
                                                    {
                                                        foreach (MusicalInstrument item in array)
                                                        {
                                                            item.Show();
                                                        }
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    default:
                                        if (ans > 5)
                                            Console.WriteLine("Неправильно введен пункт");
                                        break;
                                }
                            } while (ans != 5);
                            
                            break;
                        }

                    case 2: //Работа с массивом, состоящим из объектов классов иерархии и класса Student
                        {
                            Console.WriteLine(" ==== ИСХОДНЫЙ МАССИВ СФОРМИРОВАН === ");

                            int ans;
                            bool isConvert;

                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("1. Печать массива");
                                Console.WriteLine("2. Подсчет количества объектов каждого типа ");
                                Console.WriteLine("3. Назад");
                                Console.WriteLine();

                                do
                                {
                                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                                    if (!isConvert)
                                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                                } while (!isConvert);

                                switch (ans)
                                {
                                    case 1: // Печать массива
                                        {
                                            PrintArray2(array2);
                                            break;
                                        }
                                    case 2: // Подсчет количества объектов каждого типа
                                        {
                                            Console.WriteLine("== Подсчет количества объектов каждого типа ==");
                                            Console.WriteLine($"Количество обектов класса MusicalInstrument: {countMusical}");
                                            Console.WriteLine($"Количество обектов класса Guitar: {countGuitar}");
                                            Console.WriteLine($"Количество обектов класса ElectricGuitar: {countElectricGuitar}");
                                            Console.WriteLine($"Количество обектов класса Piano: {countPiano}");
                                            Console.WriteLine($"Количество обектов класса Student: {countStudent}");
                                            break;
                                        }
                                    default:
                                        if (ans > 3)
                                        Console.WriteLine("Неправильно введен пункт меню"); 
                                        break;
                                }
                            } while (ans != 3);                          
                            break;
                        }

                    case 3: // Поверхстное и глубое копирование объекта
                        {
                            MusicalInstrument m2 = new MusicalInstrument();
                            m2.IRandomInit();
                            Console.WriteLine(m2);
                            MusicalInstrument copy = (MusicalInstrument)m2.ShallowCopy();
                            Console.WriteLine(copy);
                            MusicalInstrument clon = m2.Clone() as MusicalInstrument;
                            Console.WriteLine(clon);

                            Console.WriteLine(" == С изменениями  ==");
                            copy.Name = "Copy" + m2.Name;
                            copy.id.Number = 150;
                            clon.Name = "Clon" + m2.Name;
                            clon.id.Number = 30;
                            Console.WriteLine(m2);
                            Console.WriteLine(copy);
                            Console.WriteLine(clon);
                            break;
                        }

                    default:
                        if (answer > 4)
                            Console.WriteLine("Неправильно введен пункт меню"); 
                        break;
                }
            } while (answer != 4);
        }
    }
}
