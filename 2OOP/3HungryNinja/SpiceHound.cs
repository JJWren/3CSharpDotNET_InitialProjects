using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class SpiceHound : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull
        {
            get
            {
                return calorieIntake >= 1200;
            }
        }

        public override void Consume(IConsumable item)
        {
            // provide override for Consume
            if (IsFull == false)
            {
                ConsumptionHistory.Add(item);
                if (item.IsSpicy == true)
                {
                    calorieIntake += item.Calories - 5;
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