using System;

namespace ArrayOopTask
{
    public class ArrayProcessor
    {
        private int[] numbers;

        public int[] Numbers => (int[])numbers.Clone();

        public ArrayProcessor(int[] array)
        {
            numbers = array ?? throw new ArgumentNullException(nameof(array));
        }

        public long GetSumOfAbsoluteNegativeElements()
        {
            long sum = 0;
            foreach (int item in numbers)
            {
                if (item < 0)
                {
                    sum += Math.Abs((long)item);
                }
            }
            return sum;
        }

        public long? GetProductBeforeLastNegative()
        {
            int lastNegativeIndex = -1;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] < 0)
                {
                    lastNegativeIndex = i;
                    break;
                }
            }

            if (lastNegativeIndex == -1)
            {
                return null;
            }

            if (lastNegativeIndex == 0)
            {
                return 0;
            }

            long product = 1;
            for (int i = 0; i < lastNegativeIndex; i++)
            {
                product *= numbers[i];
            }

            return product;
        }

        public void PrintArray()
        {
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== Оберіть спосіб заповнення масиву ===");
                Console.WriteLine("1. Введення масиву з клавіатури");
                Console.WriteLine("2. Заповнення псевдовипадковими числами [-100; 100]");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0") break;

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    continue;
                }

                int n = ReadPositiveInt("Введіть розмірність масиву n (n > 0): ");
                int[] array = new int[n];

                switch (choice)
                {
                    case "1":
                        for (int i = 0; i < n; i++)
                        {
                            array[i] = ReadInt($"Введіть елемент [{i}]: ");
                        }
                        break;

                    case "2":
                        Random rnd = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            array[i] = rnd.Next(-100, 101);
                        }
                        break;
                }

                ArrayProcessor processor = new ArrayProcessor(array);

                Console.WriteLine("\n--- Згенерований/Введений масив ---");
                processor.PrintArray();

                long sumAbsNeg = processor.GetSumOfAbsoluteNegativeElements();
                Console.WriteLine($"\n1) Сума модулів від'ємних елементів: {sumAbsNeg}");

                long? product = processor.GetProductBeforeLastNegative();
                if (product.HasValue)
                {
                    if (product.Value == 0)
                    {
                        Console.WriteLine("2) Останній від'ємний елемент є першим у масиві, тому елементи перед ним відсутні.");
                    }
                    else
                    {
                        Console.WriteLine($"2) Добуток елементів до останнього від'ємного: {product.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("2) Від'ємні елементи в масиві відсутні, обчислити добуток неможливо.");
                }
            }
        }

        static int ReadInt(string message)
        {
            int result;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Помилка! Введіть коректне ціле число: ");
            }
            return result;
        }

        static int ReadPositiveInt(string message)
        {
            int result;
            do
            {
                result = ReadInt(message);
                if (result <= 0)
                {
                    Console.WriteLine("Розмірність масиву має бути більше 0.");
                }
            } while (result <= 0);

            return result;
        }
    }
}