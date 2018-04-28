using System;

/*Клюшин А. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, 
               создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
               Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, 
               меняющий знаки у всех элементов массива, Метод Multi, умножающий каждый элемент массива на определенное число, 
               свойство MaxCount, возвращающее количество максимальных элементов. В Main продемонстрировать работу класса.
            б)*Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.*/

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Инициализация массивов разными методами
            MyArray arr1 = new MyArray(8, -30, 12, MyArray.Metod.ByRandom);
            MyArray arr2 = new MyArray(@"D:\1\dataarray.txt");
            MyArray arr3 = new MyArray(5);
            MyArray arr4 = new MyArray(50, -50, 2, MyArray.Metod.ByStep);

            //Демонстрация работы класса
            Console.WriteLine($"Начальный массив сформированный из случайных чисел:\n\n{arr1.ToString()}");
            Console.WriteLine($"\nСумма элементов массива: {arr1.Sum}");

            Console.WriteLine("\nПолучение \"инверсного\" массива:\n");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(" " + arr1.Inverse()[i]);
            }

            Console.Write("\n\nМассив умноженный на определенной число (в данном случае на 5):\n\n");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(" " + arr1.Multi(5)[i]);
            }
            
            Console.WriteLine("\n\nКолличество максимальных элементов в массиве: " + arr1.MaxCount);

            arr3.ReadFromFile(@"D:\1\dataarray.txt");
            Console.WriteLine("\nМассив считанный из файла:\n\n" + arr3.ToString());
                        
            Console.WriteLine("\n\nМассив сформированный по заданному размеру, начальному значению и шагу:\n\n" + arr4.ToString());

            arr1.WriteToFile(@"D:\1\dataarray.txt", true);

            Console.ReadLine();
        }
    }
}
