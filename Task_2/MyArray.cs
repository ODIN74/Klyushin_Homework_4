using System;
using System.Linq;
using System.IO;

namespace Task_2
{
    class MyArray
    {
        private int[] array;
        enum Metod {ByRandom, ByStep};

        public MyArray(int n)
        {
            array = new int[n];
        }

        public MyArray(int n, int element)
        {
            array = new int[n];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = element;
            }
        }

        //public MyArray(int n, int min, int max)
        //{

        //    Random rnd = new Random();
        //    array = new int[n];
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        array[i] = rnd.Next(min, max);
        //    }
        //}

        public MyArray(int n, int initial, int step)
        {
            array = new int[n];
            array[0] = initial;
            for (int i = 1; i < array.Length; i++)
            {
                array[i] += array[i - 1] + step;
            }
        }

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

        public int Length
        {
            get { return array.Length; }
        }

        public int[] Inverse()
        {
            int[] b = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {

                b[i] = array[i] * (- 1);
            }
            return b;
        }

        public int[] Multi(int multiplier)
        {
            int[] b = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {

                b[i] = array[i] * multiplier;
            }
            return b;
        }

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
