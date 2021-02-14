using System;

namespace Human
{
    class Ninja : Human
    {
        public Ninja() : base()
        {
            Dexterity = 175;
        }

        public Ninja(string n) : base(n)
        {
            Name = n;
            Dexterity = 175;
        }

        // Build Attack method
        public override void Attack(Human target)
        {
            Random rand = new Random();
            int RNG = rand.Next(0, 100);

            Console.WriteLine($"{Name} attacked {target.Name}!");

            int dmg = 5 * Dexterity;
            if (RNG <= 19)
            {
                dmg += 10;
            }
            target.Health -= dmg;
            Console.WriteLine($"{target.Name} took {dmg} points of damage!");
        }

        public void Steal(Human target)
        {
            Console.WriteLine($"{Name} stole 5 point of health from {target.Name}!");
            target.Health -= 5;
            Health += 5;
        }
    }
}