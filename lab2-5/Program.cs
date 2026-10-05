using System;

namespace MatrixColumnSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Програма для обміну стовпців матриці місцями ===");

                int n = ReadPositiveInt("Введіть кількість рядків n (n > 0): ");
                int m = ReadPositiveInt("Введіть кількість стовпців m (m > 0): ");

                int[,] matrix = new int[n, m];

                Console.WriteLine("\nОберіть спосіб заповнення матриці:");
                Console.WriteLine("1 — Введення елементів з клавіатури");
                Console.WriteLine("2 — Генерація псевдовипадкових чисел [-100; 100]");
                Console.WriteLine("0 — Вихід");
                int mode = ReadIntInRange("Ваш вибір (0, 1 або 2): ", 0, 2);

                if (mode == 0)
                {
                    Console.WriteLine("\nРоботу програми завершено. До побачення!");
                    break;
                }
                else if (mode == 1)
                {
                    FillMatrixManual(matrix, n, m);
                }
                else if (mode == 2)
                {
                    FillMatrixRandom(matrix, n, m);
                }

                Console.WriteLine("\nПочаткова матриця A:");
                PrintMatrix(matrix, n, m);

                Console.WriteLine($"\nВведіть номери стовпців для обміну (від 1 до {m}):");
                int kUser = ReadIntInRange($"Введіть номер першого стовпця k (1..{m}): ", 1, m);
                int pUser = ReadIntInRange($"Введіть номер другого стовпця p (1..{m}): ", 1, m);

                int k = kUser - 1;
                int p = pUser - 1;

                SwapColumns(matrix, n, k, p);

                Console.WriteLine($"\nМатриця A після обміну стовпців {kUser} та {pUser}:");
                PrintMatrix(matrix, n, m);

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        static int ReadPositiveInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Помилка! Введіть додатне ціле число.");
            }
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Помилка! Введіть ціле число в межах від {min} до {max}.");
            }
        }

        static void FillMatrixManual(int[,] matrix, int n, int m)
        {
            Console.WriteLine("\n--- Ручне введення елементів матриці ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    while (true)
                    {
                        Console.Write($"A[{i + 1},{j + 1}] = ");
                        if (int.TryParse(Console.ReadLine(), out int val))
                        {
                            matrix[i, j] = val;
                            break;
                        }
                        Console.WriteLine("Некоректне значення! Введіть ціле число.");
                    }
                }
            }
        }

        static void FillMatrixRandom(int[,] matrix, int n, int m)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(-100, 101);
                }
            }
            Console.WriteLine("\nМатрицю успішно заповнено генератором випадкових чисел.");
        }

        static void SwapColumns(int[,] matrix, int n, int k, int p)
        {
            if (k == p) return;

            for (int i = 0; i < n; i++)
            {
                int temp = matrix[i, k];
                matrix[i, k] = matrix[i, p];
                matrix[i, p] = temp;
            }
        }

        static void PrintMatrix(int[,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],6} ");
                }
                Console.WriteLine();
            }
        }
    }
}