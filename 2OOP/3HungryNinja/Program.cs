using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new instances of ST, SH, and Buffet
            SweetTooth Candy = new SweetTooth();
            SpiceHound Pepper = new SpiceHound();
            Buffet RandoCheapy = new Buffet();

            // Make ST and SH lil gluttons :D
            Candy.ConsumeUntilFull();
            Pepper.ConsumeUntilFull();
            Candy.Consume(RandoCheapy.Serve());
            Pepper.Consume(RandoCheapy.Serve());

            // Who ate more - Pepper or Candy?
            Candy.CompareConsumption(Pepper);
        }
    }
}
