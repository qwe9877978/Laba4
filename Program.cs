using LabaWork4_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabaWork4_2
{
    class Program
    {
        private static Money currentMoney = new Money(10, 50); // Начальный объект для тестирования

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine($"Текущая сумма: {currentMoney}");
                Console.WriteLine("1 - Задание 6: Конструкторы и метод AddKopeks");
                Console.WriteLine("2 - Задание 7: Перегруженные операции");
                Console.WriteLine("3 - Изменить текущую сумму");
                Console.WriteLine("4 - Показать информацию о текущей сумме");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        TestTask6();
                        break;
                    case "2":
                        TestTask7();
                        break;
                    case "3":
                        ChangeCurrentMoney();
                        break;
                    case "4":
                        ShowMoneyInfo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        static void TestTask6()
        {
            Console.WriteLine("\n--- ЗАДАНИЕ 6: Конструкторы и метод AddKopeks ---");

            try
            {
                // Тестирование конструкторов
                Console.WriteLine("\n1. Тестирование конструкторов:");
                Money money1 = new Money(15, 75);
                Console.WriteLine($"Конструктор с параметрами (15,75): {money1}");

                Money money2 = new Money();
                Console.WriteLine($"Конструктор по умолчанию: {money2}");

                Money money3 = new Money(currentMoney);
                Console.WriteLine($"Конструктор копирования (от текущей суммы): {money3}");

                // Тестирование метода AddKopeks на текущем объекте
                Console.WriteLine($"\n2. Тестирование метода AddKopeks на текущей сумме: {currentMoney}");
                Console.Write("Введите количество копеек для добавления: ");
                uint kopeksToAdd = GetUintInput();

                Money result = currentMoney.AddKopeks(kopeksToAdd);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void TestTask7()
        {
            Console.WriteLine("\n--- ЗАДАНИЕ 7: Перегруженные операции ---");

            try
            {
                Console.WriteLine($"Текущая сумма: {currentMoney}");

                // Тестирование унарных операторов
                Console.WriteLine("\n1. Тестирование унарных операторов:");
                Money plusPlus = new Money(currentMoney);
                plusPlus++;
                Console.WriteLine($"money++: {plusPlus}");

                Money minusMinus = new Money(currentMoney);
                minusMinus--;
                Console.WriteLine($"money--: {minusMinus}");

                // Тестирование операторов приведения
                Console.WriteLine("\n2. Тестирование операторов приведения:");
                uint rublesOnly = (uint)currentMoney;
                Console.WriteLine($"(uint)money (только рубли): {rublesOnly} руб.");

                double kopeksOnly = currentMoney;
                Console.WriteLine($"(double)money (только копейки в рублях): {kopeksOnly:F2} руб.");

                // Тестирование бинарных операторов
                Console.WriteLine("\n3. Тестирование бинарных операторов:");
                Console.Write("Введите количество копеек для операций: ");
                uint kopeksForOp = GetUintInput();

                Money plusRight = currentMoney + kopeksForOp;
                Console.WriteLine($"money + {kopeksForOp}: {plusRight}");

                Money plusLeft = kopeksForOp + currentMoney;
                Console.WriteLine($"{kopeksForOp} + money: {plusLeft}");

                Money minusRight = currentMoney - kopeksForOp;
                Console.WriteLine($"money - {kopeksForOp}: {minusRight}");

                Money minusLeft = kopeksForOp - currentMoney;
                Console.WriteLine($"{kopeksForOp} - money: {minusLeft}");

                // Дополнительные тесты
                Console.WriteLine("\n4. Дополнительные тесты:");

                // Тест с нулевыми значениями
                Money zeroMoney = new Money(0, 0);
                Console.WriteLine($"Нулевая сумма: {zeroMoney}");
                zeroMoney--;
                Console.WriteLine($"После --: {zeroMoney}");

                // Тест с большими значениями
                Money largeMoney = new Money(100, 0);
                Money result = largeMoney - 10000; // 100 руб - 10000 коп = 0 руб
                Console.WriteLine($"100 руб - 10000 коп = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ChangeCurrentMoney()
        {
            Console.WriteLine("\n--- Изменение текущей суммы ---");
            Console.WriteLine($"Текущая сумма: {currentMoney}");

            try
            {
                Console.Write("Введите новое количество рублей: ");
                uint rubles = GetUintInput();
                Console.Write("Введите новое количество копеек: ");
                byte kopeks = GetByteInput();

                currentMoney = new Money(rubles, kopeks);
                Console.WriteLine($"Новая текущая сумма: {currentMoney}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании суммы: {ex.Message}");
            }
        }

        static void ShowMoneyInfo()
        {
            Console.WriteLine("\n--- Информация о текущей сумме ---");
            Console.WriteLine($"Текущий объект Money: {currentMoney}");
            Console.WriteLine($"Свойство Rubles: {currentMoney.Rubles}");
            Console.WriteLine($"Свойство Kopeks: {currentMoney.Kopeks}");
            Console.WriteLine($"ToString(): {currentMoney.ToString()}");
        }

        static uint GetUintInput()
        {
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out uint result))
                    return result;
                Console.Write("Ошибка! Введите целое неотрицательное число: ");
            }
        }

        static byte GetByteInput()
        {
            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out byte result) && result < 100)
                    return result;
                Console.Write("Ошибка! Введите число от 0 до 99: ");
            }
        }
    }
}
