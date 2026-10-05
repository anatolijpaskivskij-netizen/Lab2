using System;

namespace LabTask2
{
    class Program
    {
        static string CalculateY(double x)
        {
            if (Math.Abs(x) < 1e-10)
            {
                return "Невизначено (ділення на 0)";
            }

            double y = Math.Sin(x) / x;
            return $"{y,12:F6}";
        }

        static void PrintTableHeader()
        {
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"| {"x",15} | {"y = f(x)",23} |");
            Console.WriteLine(new string('-', 45));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double a = -Math.PI / 2.0;
            double b = Math.PI / 2.0;
            double dx = Math.PI / 30.0;

            // ----------------------------------------------------
            // 1. Обчислення за допомогою циклу З ПЕРЕДУМОВОЮ (while)
            // ----------------------------------------------------
            Console.WriteLine("=== Результати обчислення (Цикл з передумовою while) ===");
            Console.WriteLine($"Результати обчислення функції y = f(x) на проміжку [{a:F2}, {b:F2}] з кроком dx = {dx:F4}\n");

            PrintTableHeader();

            double x = a;

            while (x <= b + dx / 2)
            {
                Console.WriteLine($"| {x,15:F6} | {CalculateY(x),23} |");
                x += dx;
            }
            Console.WriteLine(new string('-', 45));


            // ----------------------------------------------------
            // 2. Обчислення за допомогою циклу З ПІСЛЯУМОВОЮ (do...while)
            // ----------------------------------------------------
            Console.WriteLine("\n=== Результати обчислення (Цикл з післяумовою do...while) ===");
            Console.WriteLine($"Результати обчислення функції y = f(x) на проміжку [{a:F2}, {b:F2}] з кроком dx = {dx:F4}\n");

            PrintTableHeader();

            x = a;
            do
            {
                Console.WriteLine($"| {x,15:F6} | {CalculateY(x),23} |");
                x += dx;
            } while (x <= b + dx / 2);

            Console.WriteLine(new string('-', 45));

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}