using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class SweetTooth : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull
        {
            get
            {
                Console.WriteLine($"from inside \"IsFull\" calintake: {calorieIntake}");
                // if calorieIntake >= 1500, this returns true... otherwise false!
                return calorieIntake >= 1500;
            }
        }

        public override void Consume(IConsumable item)
        {
            // provide override for Consume
            if (IsFull == false)
            {
                ConsumptionHistory.Add(item);
                if (item.IsSweet == true)
                {
                    calorieIntake += item.Calories + 10;
                }
                else
                {
                    calorieIntake += item.Calories;
                }
            }
            else
            {
                Console.WriteLine("Too full to eat anymore!");
            }
        }
    }
}