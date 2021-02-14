using System;
using System.Collections.Generic;


namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // THREE BASIC ARRAYS
            int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numArray)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("");

            string[] nameArray = { "Tim", "Martin", "Nikki", "Sara" };
            foreach (string name in nameArray)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("");


            bool[] boolArray = { true, false, true, false, true, false, true, false, true, false };
            foreach (bool value in boolArray)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("");

            // LIST OF FLAVORS
            List<string> iceCream = new List<string>();

            iceCream.Add("Rocky Road");
            iceCream.Add("Cookie Cake");
            iceCream.Add("Cherry Garcia");
            iceCream.Add("Neopolitan");
            iceCream.Add("Turtle Tracks");

            Console.WriteLine(iceCream.Count);

            iceCream.RemoveAt(2);
            Console.WriteLine(iceCream.Count);
            Console.WriteLine("");

            // USER INFO DICTIONARY
            Dictionary<string, string> nameFlavor = new Dictionary<string, string>();

            foreach (string name in nameArray)
            {
                // randFlavor is a random index from iceCream arr
                int randFlavor = new Random().Next(0, 3);
                nameFlavor.Add(name, iceCream[randFlavor]);
            }

            foreach (KeyValuePair<string, string> item in nameFlavor)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
