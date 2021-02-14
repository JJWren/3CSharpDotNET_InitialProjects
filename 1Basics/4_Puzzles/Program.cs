using System;
using System.Collections.Generic;


namespace Puzzles
{
    public static class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(108);
            Names();
        }

        public static void writeArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write(arr[arr.Length - 1] + "]");
        }

        public static void writeList(List<string> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.Write(list[list.Count - 1] + "]");
        }

        // -----RANDOM ARRAY-----
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values

        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5, 26);
            }

            Console.WriteLine("Your randomized array is:");
            writeArray(arr);
            Console.WriteLine("");

            int min = arr[0], max = arr[0], sum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
                if (max < arr[i])
                {
                    max = arr[i];
                }
                sum += arr[i];
            }

            Console.WriteLine("Min: {0} | Max: {1} | Sum: {2}\n", min, max, sum);

            return arr;
        }

        // -----COIN FLIP-----
        // Create a function called TossCoin() that returns a string
        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        // Finally, return the result

        // Create another function called TossMultipleCoins(int num) that returns a Double
        // Have the function call the tossCoin function multiple times based on num value
        // Have the function return a Double that reflects the ratio of head toss to total toss

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");

            Random rand = new Random();
            int coinToss = rand.Next(0, 2);
            if (coinToss == 1)
            {
                Console.WriteLine("Heads\n");
                return "Heads";
            }
            else
            {
                Console.WriteLine("Tails\n");
                return "Tails";
            }
        }

        public static double TossMultipleCoins(int num)
        {
            double hCount = 0, tCount = 0;
            for (double i = 0; i <= num; i++)
            {
                string temp = TossCoin();
                if (temp == "Heads")
                {
                    hCount++;
                }
                else
                {
                    tCount++;
                }
            }
            double hTotalRatio = (hCount / num) * 100;

            Console.WriteLine("Your percentage of heads versus total flips is {0}%.\n", hTotalRatio);

            return hTotalRatio;
        }

        // -----NAMES-----
        // Build a function Names that returns a list of strings.  In this function:
        // Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the list and print the values in the new order
        // Return a list that only includes names longer than 5 characters

        // There is no built-in method to support the randomization of a List. This creates an extension method that adds this functionality to any provided List. `rng` should be declared as a global variable so that only one Random object is created. - https://www.programming-idioms.org/idiom/10/shuffle-a-list/1352/csharp
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<string> Names()
        {
            List<string> nameList = new List<string>();
            nameList.AddRange(new string[]
            {
                "Todd",
                "Tiffany",
                "Charlie",
                "Geneva",
                "Sydney"
            });
            Console.WriteLine("The original name list is:");
            writeList(nameList);
            Console.WriteLine("");

            Random rand = new Random();
            Shuffle(nameList);
            Console.WriteLine("The shuffled name list is:");
            writeList(nameList);
            Console.WriteLine("");

            for (int i = 0; i < nameList.Count; i++)
            {
                if (nameList[i].Length < 5)
                {
                    nameList.RemoveAt(i);
                }
            }

            Console.WriteLine("The shuffled name list with words smaller than 5 letters is:");
            writeList(nameList);
            Console.WriteLine("");

            return nameList;
        }
    }
}
