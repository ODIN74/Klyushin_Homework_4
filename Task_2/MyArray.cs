using System;
using System.Linq;
using System.IO;

namespace Task_2
{
    class MyArray
    {
        //Определение поля класса
        private int[] array;

        //Определение нумерованного списка для конструктора массива
        public enum Metod {ByRandom, ByStep};
        
        //Конструктор пустого массива
        public MyArray(int size)
        {
            array = new int[size];
        }

        //Конструктор массива заполненного определенным числом
        public MyArray(int size, int element)
        {
            array = new int[size];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = element;
            }
        }

        //Конструктор массива с заданной длинной и возможностью выбора генерации значения через random или от начального значения с определенным шагом
        public MyArray(int size, int initial, int finalOrStep, Metod metod)
        {
            if (metod == Metod.ByRandom)
            {
                Random rnd = new Random();
                array = new int[size];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(initial, finalOrStep);
                }
            }

            else if(metod == Metod.ByStep)
            { 
                array = new int[size];
                array[0] = initial;
                for (int i = 1; i < array.Length; i++)
                {
                        array[i] = array[i - 1] + finalOrStep;
                }     
            }
        }

        //Конструктор массива считывающего значения из файла
        public MyArray(string path)
        {
            if (File.Exists(path))
            {
                string[] fromfile = File.ReadAllLines(path);
                array = new int[fromfile.Length];
                for (int i = 0; i < fromfile.Length; i++)
                {
                    array[i] = int.Parse(fromfile[i]);
                }
            }
            else
            {
                Console.WriteLine("Файл не существует");
                Console.ReadLine();
            }
        }

        //Свойство возвращающее максимальный элемент массива
        public int Max
        {
            get
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    max = array[i] > max ? array[i] : max;
                }
                return max;
            }
        }

        //Свойство возвращающее минимальный элемент массива
        public int Min
        {
            get {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    min = array[i] < min ? array[i] : min;
                }
                return min;
            }
        }

        //Свойство возвращающее сумму элементов массива
        public int Sum
        {
            get {
                int sum = 0;
                for(int i=0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }
        }

        //Свойство возвращающее колличество максимальных элементов в массиве
        public int MaxCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    count = array[i] == array.Max() ? count + 1 : count; 
                }
                return count;
            }
        }

        //Свойство возвращающее длинну массива
        public int Length
        {
            get { return array.Length; }
        }

        //Метод возвращающий инверсный массив
        public int[] Inverse()
        {
            int[] b = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {

                b[i] = array[i] * (- 1);
            }
            return b;
        }

        //Метод возвращающий массив элементов массива умноженных на определенное число
        public int[] Multi(int multiplier)
        {
            int[] b = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {

                b[i] = array[i] * multiplier;
            }
            return b;
        }

        //Метод чтения файла и записи его в массив (с изменением размерности массива если в файле больше/меньше элементов)
        public void ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                string[] fromfile = File.ReadAllLines(path);
                if (array.Length != fromfile.Length)
                {
                    Array.Resize(ref array, fromfile.Length);
                }
                    for (int i = 0; i < fromfile.Length; i++)
                    {
                        array[i] = int.Parse(fromfile[i]);
                    }
                
            }
            else
            {
                Console.WriteLine("Файл не существует");
                Console.ReadLine();
            }
        }

        //Метод записи в файл с возможностью выбора перезаписывать файл или создавать новый 
        //(в случае записи в новый файл проверяется также нет ли файла с сгенерированным именем)
        public void WriteToFile(string path, bool rewriteFile)
        {

            string[] arrayToString = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayToString[i] = array[i].ToString();
            }
            if (!rewriteFile)
            {
                while (File.Exists(path))
                {
                    char[] pathToChar = new char[path.ToCharArray().Length];
                    pathToChar = path.ToCharArray();
                    char[] helper = new char[4];
                    for (int i = 0; i < 4; i++)
                    {
                        helper[i] = pathToChar[pathToChar.Length - 1 - i];
                    }
                    Array.Resize(ref pathToChar, pathToChar.Length + 1);
                    pathToChar[pathToChar.Length - 5] = '1';
                    for (int i = 0; i < 4; i++)
                    {
                        pathToChar[pathToChar.Length - 1 - i] = helper[i];
                    }
                    path = new string(pathToChar);
                }
            }
            File.WriteAllLines(path, arrayToString);
        }

        //Переопределенный метод преобразования массива в строку
        public override string ToString()
        {
            if (array != null)
            {
                string s = String.Empty;
                for (int i = 0; i < array.Length; i++)
                {
                    s += " " + array[i];
                }
                return s;
            }
            else return "Массив пуст";
        }
    }
}
