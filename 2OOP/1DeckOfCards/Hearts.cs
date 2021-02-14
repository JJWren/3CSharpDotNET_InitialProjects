using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Hearts : Card
    {
        public Hearts(int v) : base(v)
        {
            suit = "Hearts";
            val = v;
            cardName = $"{stringVal} of {suit}";
        }
    }
}