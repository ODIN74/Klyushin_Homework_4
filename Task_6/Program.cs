using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Клюшин А. ***Написать игру “Верю. Не верю”. В файле хранятся некоторые данные и правда это или нет.
            Например: “Шариковую ручку изобрели в древнем Египте”, “Да”.
            Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задает их игроку.
            Игрок пытается ответить правда или нет, то что ему загадали и набирает баллы. */

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {

            //проверка на наличие файла и отмена игры в случае его отсутствия
            if (File.Exists(@"D:\Anton\C Sharp\lesson5\questions.csv"))
            {
                string[,] questions = ReadCsvToArray(';', @"D:\Anton\C Sharp\lesson4\questions.csv");
                int sumOfQuestions = questions.GetLength(0);
                int counterQuestions = 0;
                int points = 0;
                string answer = String.Empty;
                Random Rnd = new Random();

                //инициализируем массив для записи индексов заданных вопросов
                int[] numbersOfQuestion = new int[4];
                int newQuestion = 0;

                Console.WriteLine("Добро пожаловать в игру \"Верю. Не вкерю\".\n\nВам будет задано 5 вопросов,\nа потом мы посмотрим сколько баллов Вы набрали.");
                Console.ReadLine();

                //организуем цикл для организации игрового процесса
                while (counterQuestions < 5)
                {
                    //цикл для исключения повтора вопросов
                    do
                    {
                        newQuestion = Rnd.Next(1, sumOfQuestions);
                    } while (ChekQuestionRepeat(numbersOfQuestion, newQuestion));

                    Console.Clear();
                    Console.WriteLine("Ответьте Да или Нет на следующий вопрос:\n");
                    Console.WriteLine(questions[newQuestion, 0]+"\n");
                    answer = Console.ReadLine();
                    
                    if(answer.ToLower() == questions[newQuestion,1].ToLower()) //верный ответ
                    {
                        Console.WriteLine("\n\nВы ответили верно!");
                        points++;
                        Console.ReadLine();
                    }
                    else if(answer.ToLower() != "да" && answer.ToLower() != "нет") //обработка если введено что-то отличное от "да" или "нет"
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели что-то не то. Нужно вводить только Да или Нет.\nПостарайтесь не ошибиться в следующем вопросе.");
                        Console.ReadLine();
                    }
                    else //неверный ответ
                    {
                        Console.WriteLine("\n\nВы ответили не верно!");
                        Console.ReadLine();
                    }
                    counterQuestions++;
                }

                Console.Clear();
                Console.WriteLine($"И так вы набрали {points} очков. Спасибо за игру!");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Игра сейчас невозможна. Файл с вопросами не найден.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            
        }

        //метод чтения из файла в двумерный массив
        static string[,] ReadCsvToArray(char separator, string path)
        {
            //считываем строки файла
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            //определяем колличество столбцов
            string[] columns = lines[0].Split(separator);

            //проверка файла на повреждение
            if (columns.Length != 2)
            {
                Console.WriteLine("Игра сейчас невозможна. Файл с вопросами поврежден.");
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }
            else
            {
                //формируем массив из массива считанных строк
                string[,] questions = new string[lines.Length, 2];
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < columns.Length; j++)
                    {
                        columns = lines[i].Split(separator);

                        //проверка файла на повреждение
                        if (columns.Length != 2)
                        {
                            Console.WriteLine("Игра сейчас невозможна. Файл с вопросами поврежден.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            return null;
                        }
                        else
                        {
                            questions[i, j] = columns[j];
                        }
                    }
                }
                return questions;
            }
        }

        //метод проверки задавался ли уже такой вопрос
        static bool ChekQuestionRepeat(int[] numbersOfQuestions, int newQuestion)
        {
            bool flag = false;
            for(int i = 0; i < numbersOfQuestions.Length; i++)
            {
                if (numbersOfQuestions[i] == newQuestion)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

    }
}
