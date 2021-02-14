using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Clubs : Card
    {
        public Clubs(int v) : base(v)
        {
            suit = "Clubs";
            val = v;
            cardName = $"{stringVal} of {suit}";
        }
    }
}