using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            TwodimensionalArray arr = new TwodimensionalArray(4, 5, -10, 20);

            DisplayToConsole(arr);
            Console.ReadLine();
        }

        public void DisplayToConsole(TwodimensionalArray array)
        {
            string line = String.Empty;

            for (int i = 0; i < array.LengthByLines; i++)
            {
                line = String.Empty;
                for (int j = 0; j < array.LengthByColumns; j++)
                {
                    line += " " + array[i, j];
                }
                Console.WriteLine("\n" + line);
            }

        }
    }
}
