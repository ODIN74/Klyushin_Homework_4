using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            TwodimensionalArray arr = new TwodimensionalArray(4, 5, -10, 20);
            int index = 0;

            Console.WriteLine("Демонстрация работы собственного класса двумерных массивов:\n");
            Console.WriteLine($"Массив заполненный случайными числами:\n\n{arr.ToString()}");
            Console.WriteLine($"\nМаксимальный элемент данного массива: {arr.Max}");
            arr.IndexOfMaxElement(ref index);
            Console.WriteLine($"\nИндекс этого элемента: {index}");
            Console.WriteLine($"\nМинимальный элемент данного массива: {arr.Min}");
            Console.WriteLine($"\nСумма всех элементов данного массива: {arr.SumElements()}");
            Console.WriteLine($"\nСумма элементов данного массива больше чем заданное число: {arr.SumElementsGreaterThan(0)}");
            Console.WriteLine($"\nСумма элементов данного массива начиная с заданного элемента (индекса): {arr.SumElements(8)}");

            //демонстрация метода записи в файл
            arr.WriteToFile(@"D:\1\array1.csv",';', true);
            
            //создаем массив с элементами считанными из csv файла
            TwodimensionalArray arr2 = new TwodimensionalArray(@"D:\1\array.csv",';');
            Console.WriteLine($"\nМассив заполненный числами из файла:\n\n{arr2.ToString()}");
            Console.ReadLine();
      
        }
    }
}
