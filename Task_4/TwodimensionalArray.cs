using System;
using System.IO;


namespace Task_4
{
    class TwodimensionalArray
    {
        int[,] array;
        //private int lines = array.GetLength(0);
        //private int columns = array.GetLength(1);

        //конструктор массива с заданными размерами
        public TwodimensionalArray(int lines, int columns)
        {
            array = new int[lines, columns];
        }

        //конструктор массива заполненный случайными элементами из указанного интервала
        public TwodimensionalArray(int line, int column, int min, int max)
        {
            array = new int[line, column];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
            }
        }

        //конструктор массива загружающий данные из csv файла с возможностью определения разделителя
        public TwodimensionalArray(string path, char separator)
        {
            if (File.Exists(path))
            {
                string[] linesFromFile = File.ReadAllLines(path);
                int lines = linesFromFile.Length;
                //array = new int[fromfile.Length];
                int lengthOfLine = (linesFromFile[0].Split(separator)).Length;

                array = new int[lines, lengthOfLine];

                for (int i = 0; i < lines; i++)
                {
                    string[] line = linesFromFile[i].Split(separator);
                    for (int j = 0; j < lengthOfLine; j++)
                    {
                        array[i, j] = int.Parse(line[j]);
                    } 
                }
            }
            else
            {
                Console.WriteLine("Файл не существует");
                Console.ReadLine();
            }
        }

        //свойство, возвращающее минимальное значение массива
        public int Min
        {
            get
            {
                int min = array[0, 0];
                foreach(var element in array)
                {
                    if (element < min) min = element;
                }
                return min;
            }
        }

        //свойство, возвращающее максимальное значение массива
        public int Max
        {
            get
            {
                int max = array[0, 0];
                foreach (var element in array)
                {
                    if (element > max) max = element;
                }
                return max;
            }
        }


        //метод возвращающий сумму элементов массива
        public int SumElements()
        {
                int sumAllElements = 0;
                foreach(var element in array)
                {
                    sumAllElements += element;
                }
                return sumAllElements;

        }

        //метод возвращающий сумму элементов массива, начиная с определенного элемента массива
        public int SumElements(int initialIndex)
        {
            int sumElements = 0;

             for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if(array.GetLength(1)*i+j >= initialIndex)
                    {
                        sumElements += int.Parse(array.GetValue(i,j).ToString());
                    }
                }
            }
            return sumElements;
        }

        //метод возвращающий сумму элементов массива, которые больше чем заданное число
        public int SumElementsGreaterThan(int initial)
        {
            int sumElements = 0;
            foreach(var element in array)
            {
                if(element > initial)
                {
                    sumElements += element;
                }
            }
            return sumElements;
        }

        //метод, возвращающий номер максимального элемента массива используя модификатор ref
        public void IndexOfMaxElement(ref int index)
        {
            int max = array[0, 0];
            foreach (var element in array)
            {
                if (element > max) max = element;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == max)
                    {
                        index = array.GetLength(1) * i + j;
                    }
                }
            }
        }


        //метод записи массива в файл с возможностью выбора разделителя и выбора перезаписывать файл или нет если он существует
        public void WriteToFile(string path, char separator, bool rewriteFile)
        {
            string[] arrayToString = new string[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                string lineForWriting = String.Empty;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(j == array.GetLength(1)-1)
                    {
                        lineForWriting += array[i, j];
                        arrayToString[i] = lineForWriting;
                    }
                    else
                    {
                        lineForWriting += array[i, j] + separator.ToString();
                    }
                }
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

        //метод преобразования в строку
        public override string ToString()
        {
            string line = String.Empty;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    line += " " + array[i, j];
                }
                line += "\n";
            }

            return line;
        }
    }
}
