using System;

namespace Human
{
    class Wizard : Human
    {
        public Wizard() : base()
        {
            Intelligence = 25;
            Health = 50;
        }

        public Wizard(string n) : base(n)
        {
            Name = n;
            Intelligence = 25;
            Health = 50;
        }

        // Build Attack method
        public override void Attack(Human target)
        {
            Console.WriteLine($"{Name} attacked {target.Name}!");
            int dmg = 5 * Intelligence;
            target.Health -= dmg;
            base.Health += dmg;
            Console.WriteLine($"{target.Name} took {dmg} points of damage... and healed {dmg} points of health!");
        }

        public void Heal(Human target)
        {
            Console.WriteLine($"{Name} healed {target.Name}!");
            int restore = 10 * Intelligence;
            target.Health += restore;
            if (target.Health > target.StartingHealth)
            {
                target.Health = target.StartingHealth;
            }
            Console.WriteLine($"{target.Name} recieved {restore} points of health from {Name}'s Heal spell!");
        }
    }
}