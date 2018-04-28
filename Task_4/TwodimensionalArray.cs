using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class TwodimensionalArray
    {
        private int[,] array;

        public TwodimensionalArray(int lines, int columns)
        {
            int[,] array = new int[lines, columns];
        }

        public TwodimensionalArray(int lines, int columns, int min, int max)
        {
            int[,] array = new int[lines, columns];
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(min, max);
                }
            }
        }

        public TwodimensionalArray this[int index0, int index1]
        {
            get { return array[index0, index1]; }
        }

        public int LengthByLines 
        {
            get { return array.GetLength(0); }
        }

        public int LengthByColumns
        {
            get { return array.GetLength(1); }
        }


    }
}
