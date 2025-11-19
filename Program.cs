using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для решения задач по структурам данных");
            Console.WriteLine("================================================");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Задача 1 - Замена вхождения в List");
                Console.WriteLine("2. Задача 2 - Сортировка LinkedList");
                Console.WriteLine("3. Задача 3 - Анализ игр (HashSet)");
                Console.WriteLine("4. Задача 4 - Глухие согласные из файла (HashSet)");
                Console.WriteLine("5. Задача 5 - Результаты олимпиады (Dictionary)");
                Console.WriteLine("0. Выход из программы");
                Console.WriteLine("");
                Console.Write("Выберите задачу (введите номер): ");

                string choice = Console.ReadLine();
                Console.WriteLine("");

                switch (choice)
                {
                    case "1":
                        Tasks.ReplaceFirstOccurrence();
                        break;
                    case "2":
                        Tasks.SortLinkedList();
                        break;
                    case "3":
                        Tasks.AnalyzeGames();
                        break;
                    case "4":
                        Tasks.FindVoicelessConsonants();
                        break;
                    case "5":
                        Tasks.ProcessOlympiadResults();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы. До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Пожалуйста, введите число от 0 до 5.");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
