using System;
using first.Hello;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            // if (args.Length > 0)
            // {
            //     Console.WriteLine($"Hello {args[0]}!");
            // }
            // else
            // {
            //     Console.WriteLine("Hello!");
            // }

            // Console.WriteLine("Fibonacci Numbers 1-15:");

            // for (int i = 0; i < 15; i++)
            // {
            //     Console.WriteLine($"{i + 1}: {FibonacciNumber(i)}");
            // }
            var fibonacci = new FabonacciGenerator();
            Console.WriteLine(fibonacci.Fib(5));
            foreach (var item in fibonacci.Generate(10))
            {
                Console.WriteLine(item);
            }
        }

        static int FibonacciNumber(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }

    }
}