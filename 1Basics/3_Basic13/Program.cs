using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers();
            PrintOdds();
            PrintSum();
            int[] Arr1 = { 1, 2, 3, 4, 5 };
            LoopArray(Arr1);
            int[] Arr2 = { -3, -5, -7 };
            FindMax(Arr2);
            GetAverage(Arr1);
            OddList();
            int[] Arr3 = { 1, 3, 4, 7 };
            int Num1 = 3;
            GreaterThanY(Arr3, Num1);
            int[] Arr4 = { 1, 5, 10, -10 };
            SquareArrayValues(Arr4);
            int[] Arr5 = { 1, 5, 10, -2 };
            EliminateNegatives(Arr4);
            MinMaxAverage(Arr5);
            int[] Arr6 = { 1, 5, 10, 7, -2 };
            ShiftValues(Arr6);
            int[] Arr7 = { -1, -3, 2 };
            NumToString(Arr7);
        }

        public static void writeList(List<int> lis)
        {
            Console.Write("[");
            for (int i = 0; i < lis.Count - 1; i++)
            {
                Console.Write(lis[i] + ", ");
            }
            Console.Write(lis[lis.Count - 1] + "]");
        }

        public static void writeObject(object[] obj)
        {
            Console.Write("[");
            for (int i = 0; i < obj.Length - 1; i++)
            {
                Console.Write(obj[i] + ", ");
            }
            Console.Write(obj[obj.Length - 1] + "]");
        }

        public static void PrintNumbers()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
        }

        public static void PrintOdds()
        {
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("");
        }

        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 1; i < 256; i++)
            {
                sum += i;
                Console.WriteLine("Current Index: " + i + " | Current Sum: " + sum);
            }
            Console.WriteLine("");
        }

        public static void LoopArray(int[] numbers)
        {
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");
        }

        public static int FindMax(int[] numbers)
        {
            int max = 0;
            foreach (int value in numbers)
            {
                if (value > max)
                {
                    max = value;
                }
            }
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("");
            return max;
        }


        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            int average = sum / numbers.Length;

            Console.WriteLine("The average of the array is: " + average + "\n");
        }

        public static List<int> OddList()
        {
            List<int> List1 = new List<int>();
            for (int i = 1; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    List1.Add(i);
                }
            }

            foreach (int idx in List1)
            {
                if (idx == List1[0])
                {
                    Console.Write("{ ");
                }
                Console.Write(idx);
                if (idx < List1[List1.Count - 1])
                {
                    Console.Write(", ");
                }
                if (idx == List1[List1.Count - 1])
                {
                    Console.Write(" }\n\n");
                }
            }

            return List1;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            foreach (int num in numbers)
            {
                if (num > y)
                {
                    count++;
                }
            }

            Console.WriteLine("There are " + count + " values in the array greater than " + y + ".\n");

            return count;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            List<int> SquareOfArr = new List<int>();

            foreach (int value in numbers)
            {
                int square = value * value;
                SquareOfArr.Add(square);
            }

            writeList(SquareOfArr);
            Console.WriteLine("");
        }

        public static void EliminateNegatives(int[] numbers)
        {
            List<int> RmvdNegs = new List<int>();

            foreach (int value in numbers)
            {
                if (value < 0)
                {
                    RmvdNegs.Add(0);
                }
                else
                {
                    RmvdNegs.Add(value);
                }
            }

            writeList(RmvdNegs);
            Console.WriteLine("");
        }

        public static void MinMaxAverage(int[] numbers)
        {
            float min = numbers[0], max = numbers[0], sum = 0, avg = 0;

            foreach (int idx in numbers)
            {
                if (idx < min)
                {
                    min = idx;
                }
                if (idx > max)
                {
                    max = idx;
                }
                sum += idx;
            }

            avg = sum / numbers.Length;

            Console.WriteLine("Min: {0} | Max: {1} | Avg: {2}\n", min, max, avg);
        }

        public static void ShiftValues(int[] numbers)
        {
            numbers[0] = 0;

            List<int> ShiftedValue = new List<int>();
            for (int i = 1; i < numbers.Length; i++)
            {
                ShiftedValue.Add(numbers[i]);
            }

            ShiftedValue.Add(numbers[0]);

            writeList(ShiftedValue);
            Console.WriteLine("\n");
        }

        public static object[] NumToString(int[] numbers)
        {
            object[] dojoArray = new object[numbers.Length];

            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx] < 0)
                {
                    dojoArray[idx] = "Dojo";
                }
                else
                {
                    dojoArray[idx] = numbers[idx];
                }
            }

            writeObject(dojoArray);
            Console.WriteLine("");

            return dojoArray;
        }
    }
}
