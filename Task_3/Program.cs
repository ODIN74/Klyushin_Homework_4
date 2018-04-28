using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var attempt = 0;
            char[] separator = {';'};
            var result = false;

            if (File.Exists(@"D:\1\verification.csv"))
            {
                string[] lines = File.ReadAllLines(@"D:\1\verification.csv");
                string[] row = lines[0].Split(separator);
                if (row.Length != 2)
                {
                    Console.WriteLine("Авторизация сейчас невозможна. Файл поврежден.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    string[,] check = new string[lines.Length, 2];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        for (int j = 0; j < row.Length; j++)
                        {
                            row = lines[i].Split(separator);
                            if (row.Length != 2)
                            {
                                Console.WriteLine("Авторизация сейчас невозможна. Файл поврежден.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                            else
                            {
                                check[i, j] = row[j];
                            }

                        }
                    }

                    do
                    {
                        Console.Write("Введите логин: ");
                        string login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (login == check[i, 0])
                            {
                                if (password == check[i, 1])
                                {
                                    result = true;
                                    break;
                                }

                        }
                            else
                            {
                                Console.WriteLine("Пользователь с таким имененм не существует.");
                                Console.ReadLine();
                            }
                        }


                    }
                    while (attempt < 3);

                }
            }
            else
            {
                Console.WriteLine("Авторизация сейчас невозможна!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
