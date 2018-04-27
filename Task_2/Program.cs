using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray arr1 = new MyArray(8, -30, 12);
            Console.WriteLine(arr1.ToString());
            Console.WriteLine(arr1.Sum);
            MyArray arr2 = new MyArray(@"D:\1\dataarray.txt");
            MyArray arr3 = new MyArray(5);

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(" " + arr1.Inverse()[i]);
            }

            Console.Write("\n\n");

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(" " + arr1.Multi(2)[i]);
            }

            Console.WriteLine("\n\n" + arr1.MaxCount);

            arr3.ReadFromFile(@"D:\1\dataarray.txt");

            Console.WriteLine("\n\n" + arr3.ToString());

            arr1.WriteToFile(@"D:\1\dataarray.txt", false);

            Console.ReadLine();
        }
    }
}
