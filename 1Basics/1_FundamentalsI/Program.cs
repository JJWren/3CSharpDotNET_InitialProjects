using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Loop that prints all values from 1-255
            // for (int i = 1; i < 256; i++)
            // {
            //     Console.WriteLine(i);
            // }

            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            // for (int i = 1; i < 101; i++)
            // {
            //     if ((i % 3 == 0) && (i % 5 == 0))
            //     {
            //         continue;
            //     }
            //     else if (i % 3 == 0)
            //     {
            //         Console.WriteLine(i);
            //     }
            //     else if (i % 5 == 0)
            //     {
            //         Console.WriteLine(i);
            //     }
            // }

            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            // for (int i = 1; i < 101; i++)
            // {
            //     if ((i % 3 == 0) && (i % 5 == 0))
            //     {

            //         Console.WriteLine($"{i} - FizzBuzz");
            //     }
            //     else if (i % 3 == 0)
            //     {
            //         Console.WriteLine($"{i} - Fizz");
            //     }
            //     else if (i % 5 == 0)
            //     {
            //         Console.WriteLine($"{i} - Buzz");
            //     }
            // }

            // (Optional) If you used "for" loops for your solution, try doing the same with "while" loops. Vice-versa if you used "while" loops!
            int j = 1;
            while (j < 101)
            {
                if ((j % 3 == 0) && (j % 5 == 0))
                {

                    Console.WriteLine($"{j} - FizzBuzz");
                }
                else if (j % 3 == 0)
                {
                    Console.WriteLine($"{j} - Fizz");
                }
                else if (j % 5 == 0)
                {
                    Console.WriteLine($"{j} - Buzz");
                }
                j++;
            }
        }
    }
}
