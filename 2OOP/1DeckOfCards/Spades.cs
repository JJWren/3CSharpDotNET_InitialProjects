using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Spades : Card
    {
        public Spades(int v) : base(v)
        {
            suit = "Spades";
            val = v;
            cardName = $"{stringVal} of {suit}";
        }
    }
}