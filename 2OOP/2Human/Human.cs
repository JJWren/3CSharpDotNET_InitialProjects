using System;

namespace Human
{
    public class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        private int startingHealth;

        // add a public "getter" property to access health
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }
        public int StartingHealth
        {
            get { return startingHealth; }
        }

        // default human constructor
        public Human()
        {
            Name = "DefaultH";
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
            startingHealth = health;
        }

        // Add a constructor to assign custom values to name field
        public Human(string n)
        {
            Name = n;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        // Build Attack method
        public virtual void Attack(Human target)
        {
            Console.WriteLine($"{Name} attacked {target.Name}!");
            int dmg = 5 * Strength;
            target.Health -= dmg;
            Console.WriteLine($"{target.Name} took {dmg} points of damage!");
        }

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Health: {Health}\n");
        }
    }
}