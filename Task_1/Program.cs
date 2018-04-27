using System;

/*Клюшин А. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
            Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
            В данной задаче под парой подразумевается два подряд идущих элемента массива. 
            Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.*/

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявляем массив и объект Random
            int[] array = new int[20];
            Random rnd = new Random();

            Console.WriteLine("Исходный массив:\n");

            //инициализируем массив случайными значениями
            for (int i=0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10000);
                Console.Write(" " + array[i]);
            }

            Console.WriteLine("\n\nПары чисел, в которых хотябы одно число делится на 3:\n");

            Console.WriteLine($"\n\nКолличество пар чисел, в которых хотябы одно число делится на 3: {Convert.ToString(PairFinder(array))}");
            Console.ReadLine();

        }

        //метод поиска колличества пар чисел, в которых хотябы одно число делится на 3 (с выводом данных пар в консоль)
        static int PairFinder(int[] a)
        {
            var counterPairs = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] % 3 == 0 || a[i + 1] % 3 == 0)
                {
                    counterPairs++;
                    Console.WriteLine($"{counterPairs}. {a[i]} {a[i+1]}");
                }
            }

            return counterPairs;
        }
    }
}
