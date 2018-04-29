using System;
using System.Collections;


namespace Task_4
{
    class TwodimensionalArray
    {
        private static int[,] array;
        //private int lines = array.GetLength(0);
        //private int columns = array.GetLength(1);

        public TwodimensionalArray(int lines, int columns)
        {
            int[,] array = new int[lines, columns];
        }

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

        public int this[int index0, int index1]
        {
            get { return array[index0, index1]; }
            set { array[index0, index1] = value; }
        }


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

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public int SumElements(TwodimensionalArray array)
        {
                int sumAllElements = 0;
                foreach(var element in array)
                {
                    sumAllElements += element;
                }
                return sumAllElements;

        }

        public int SumElements(TwodimensionalArray array ,int initial)
        {
            int SumElements = 0;
            foreach(var element in array)
            {
                if (element > initial) SumElements += element;
            }
            return SumElements;
        }


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
