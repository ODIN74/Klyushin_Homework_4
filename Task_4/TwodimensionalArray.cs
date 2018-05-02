using System;
using System.Collections;


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
            int[,] array = new int[lines, columns];
        }

        //конструктор массива заполненный случайными элементами из указанного интервала
        public TwodimensionalArray(int line, int column, int min, int max)
        {
            int[,] array = new int[line, column];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
            }
        }

        //индексирование
        public int this[int index0, int index1]
        {
            get { return array[index0, index1]; }
            set { array[index0, index1] = value; }
        }

        //свойство, возвращающее минимальное значение массива
        public int Min
        {
            get
            {
                int min = this.array[0, 0];
                foreach(var element in this.array)
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
                foreach (var element in this.array)
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
                foreach(var element in this.array)
                {
                    sumAllElements += element;
                }
                return sumAllElements;

        }

        //метод возвращающий сумму элементов массива больше заданного
        public int SumElements(int initial)
        {
            int SumElements = 0;
            foreach(var element in this.array)
            {
                if (element > initial) SumElements += element;
            }
            return SumElements;
        }

        //метод преобразования в строку
        public override string ToString()
        {
            string line = String.Empty;

            for (int i = 0; i < this.array.GetLength(0); i++)
            {
                for (int j = 0; j < this.array.GetLength(1); j++)
                {
                    line += " " + this.array[i, j];
                }
                line += "\n";
            }

            return line;
        }
    }
}
