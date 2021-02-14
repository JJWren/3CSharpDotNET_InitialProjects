using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Buffet
    {
        public List<IConsumable> Menu;

        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Mac-n-cheese", 500, false, false),
                new Food("Ranch Cheddar Chicken", 500, false, false),
                new Food("Rocky Road Ice Cream", 850, false, true),
                new Food("Chocolate-Covered Jalepenos", 200, true, true),
                new Food("Caesar-Caeser Pizza", 900, false, false),
                new Food("Bone-Broth Soup", 400, true, false),
                new Food("Cinnamon Toast Crunch", 450, false, true),
                new Drink("Lemonade", 175, false),
                new Drink("Sweet Tea", 200, false),
                new Drink("Arnold Palmer", 180, false),
                new Drink("Root Beer", 250, false),
                new Drink("Yuengling", 150, false),
                new Drink("Sprite", 200, false),
                new Drink("Coca-Cola", 250, false),
                new Drink("Mountain Dew", 200, false),
                new Drink("Water", 0, false),
            };
        }

        public IConsumable Serve()
        {
            Random rand = new Random();
            int MenuIdx = rand.Next(Menu.Count);

            Console.WriteLine($"Here is your {Menu[MenuIdx].Name}. Enjoy!\n");

            return Menu[MenuIdx];
        }
    }
}