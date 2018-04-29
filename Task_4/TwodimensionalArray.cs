using System;


namespace Task_4
{
    class TwodimensionalArray
    {
        private static int[,] array;
        private int lines = array.GetLength(0);
        private int columns = array.GetLength(1);

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
