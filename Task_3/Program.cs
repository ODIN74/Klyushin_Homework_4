using System;
using System.IO;

//Клюшин А. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявляем переменные для счетчика попыток и результата авторизации
            var attempt = 0;
            var result = false;

            //проверяем наличие csv файла в директории
            if (File.Exists(@"D:\1\verification.csv"))
            {
                //считываем csv файл в двумерный массив
                string[,] users = ReadCsvToArray(';', @"D:\1\verification.csv");              

                //цикл для ограничения колличества попыток ввода
                while(attempt < 3)
                {
                    //запрашиваем у пользователя логин и пароль
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine();

                    //получаем результат авторизации
                    result = Authorization(login, password, users);

                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введено неверное имя пользователя или пароль.\nДля повторения попытки нажмите Enter.");
                        Console.ReadLine();
                        attempt++;
                    }
                        
                }

                //вывод результата в консоль
                if (result)
                {
                    Console.WriteLine("Вы успешно авторизиовались");
                }
                else
                {
                    Console.WriteLine("Превышено колличество попыток");
                }
                Console.ReadLine();   
              
            }
            else
            {
                Console.WriteLine("Авторизация сейчас невозможна!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        //метод считывания csv файла в массив
        static string[,] ReadCsvToArray(char separator, string path)
        {
            //считываем строки файла
            string[] lines = File.ReadAllLines(path);
            //определяем колличество столбцов
            string[] row = lines[0].Split(separator);

            //проверка файла на повреждение
            if (row.Length != 2)
            {
                Console.WriteLine("Авторизация сейчас невозможна. Файл поврежден.");
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }
            else
            {
                //формируем массив из массива считанных строк
                string[,] check = new string[lines.Length, 2];
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                    {
                        row = lines[i].Split(separator);
                        
                        //проверка файла на повреждение
                        if (row.Length != 2)
                        {
                            Console.WriteLine("Авторизация сейчас невозможна. Файл поврежден.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            return null;
                        }
                        else
                        {
                            check[i, j] = row[j];
                        }

                    }
                }
                return check;
            }
        }

        //метод проверки соответствия логина и пароля
        static bool Authorization(string login, string password, string[,] users)
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (login == users[i, 0])
                {
                    if (password == users[i, 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
