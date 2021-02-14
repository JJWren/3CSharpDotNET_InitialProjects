using System;

namespace Human
{
    class Samurai : Human
    {
        public Samurai() : base()
        {
            Health = 200;
        }

        public Samurai(string n) : base(n)
        {
            Name = n;
            Health = 200;
        }

        // Build Attack method
        public override void Attack(Human target)
        {
            base.Attack(target);

            if (target.Health <= 50)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} was instantly killed!");
            }
        }

        public void Meditate()
        {
            Console.WriteLine($"{Name} meditated!");
            Health = 200;
            Console.WriteLine($"{Name} fully healed from meditation...");
        }
    }
}