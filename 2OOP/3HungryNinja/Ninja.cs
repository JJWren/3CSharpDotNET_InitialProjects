using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public abstract class Ninja
    {
        protected int calorieIntake { get; set; }
        public List<IConsumable> ConsumptionHistory;
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        public abstract bool IsFull { get; }
        public abstract void Consume(IConsumable item);
        public void ConsumeUntilFull()
        {
            Buffet TheJazz = new Buffet();
            while (IsFull == false)
            {
                // TheJazz.Serve();
                Consume(TheJazz.Serve());
            }
        }
        public int CheckConsumeHist()
        {
            int count = 0;
            foreach (IConsumable item in ConsumptionHistory)
            {
                count++;
                Console.WriteLine($"Item {count}: {item.Name}");
            }
            return count;
        }

        public void CompareConsumption(Ninja VariableName)
        {
            int ThisNinjaCount = CheckConsumeHist();
            int OtherNinjaCount = VariableName.CheckConsumeHist();
            int diff;
            if (ThisNinjaCount > OtherNinjaCount)
            {
                diff = ThisNinjaCount - OtherNinjaCount;
                Console.WriteLine($"This ninja ate more than the other by {diff} items!");
            }
            else if (OtherNinjaCount > ThisNinjaCount)
            {
                diff = OtherNinjaCount - ThisNinjaCount;
                Console.WriteLine($"The other ninja ate more than the this ninja by {diff} items!");
            }
            else
            {
                Console.WriteLine("They tied!");
            }
        }
    }
}