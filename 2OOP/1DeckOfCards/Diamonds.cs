using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Diamonds : Card
    {
        public Diamonds(int v) : base(v)
        {
            suit = "Diamonds";
            val = v;
            cardName = $"{stringVal} of {suit}";
        }
    }
}