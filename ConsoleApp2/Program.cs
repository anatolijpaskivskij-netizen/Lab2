using System;

namespace HourNameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("               ГОЛОВНЕ МЕНЮ             ");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1 - Почати роботу");
                Console.WriteLine(" 0 - Вихід");
                Console.WriteLine("========================================");
                Console.Write("Оберіть пункт меню: ");

                string menuChoice = Console.ReadLine();

                if (menuChoice == "0")
                {
                    Console.WriteLine("\nДякуємо за використання! До побачення.");
                    break;
                }
                else if (menuChoice == "1")
                {
                    ExecuteHourNameLogic();
                }
                else
                {
                    Console.WriteLine("\nПомилка: невідомий пункт меню. Спробуйте ще раз.");
                    Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }
        }

        static void ExecuteHourNameLogic()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     ПРОГРАМА ВИЗНАЧЕННЯ НАЗВИ ГОДИНИ    ");
            Console.WriteLine("========================================");
            Console.Write("Введіть порядковий номер години (1-24): ");

            if (int.TryParse(Console.ReadLine(), out int n))
            {
                string hourName;

                switch (n)
                {
                    case 1: hourName = "перша година"; break;
                    case 2: hourName = "друга година"; break;
                    case 3: hourName = "третя година"; break;
                    case 4: hourName = "четверта година"; break;
                    case 5: hourName = "п'ята година"; break;
                    case 6: hourName = "шоста година"; break;
                    case 7: hourName = "сьома година"; break;
                    case 8: hourName = "восьма година"; break;
                    case 9: hourName = "дев'ята година"; break;
                    case 10: hourName = "десята година"; break;
                    case 11: hourName = "одинадцята година"; break;
                    case 12: hourName = "дванадцята година"; break;
                    case 13: hourName = "тринадцята година"; break;
                    case 14: hourName = "чотирнадцята година"; break;
                    case 15: hourName = "п'ятнадцята година"; break;
                    case 16: hourName = "шістнадцята година"; break;
                    case 17: hourName = "сімнадцята година"; break;
                    case 18: hourName = "вісімнадцята година"; break;
                    case 19: hourName = "дев'ятнадцята година"; break;
                    case 20: hourName = "двадцята година"; break;
                    case 21: hourName = "двадцять перша година"; break;
                    case 22: hourName = "двадцять друга година"; break;
                    case 23: hourName = "двадцять третя година"; break;
                    case 24: hourName = "двадцять четверта година"; break;
                    default:
                        hourName = "Помилка: число повинно бути в діапазоні від 1 до 24.";
                        break;
                }

                Console.WriteLine($"\nРезультат: {hourName}");
            }
            else
            {
                Console.WriteLine("\nПомилка: введено некоректне число.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню...");
            Console.ReadKey();
        }
    }
}