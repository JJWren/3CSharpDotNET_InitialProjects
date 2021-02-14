using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Card
    {
        // {Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King}
        public string stringVal;

        // {Clubs, Spades, Hearts, Diamonds}
        public string suit;

        // {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}
        public int val;

        public string cardName;

        public Card(int v)
        {
            stringVal = "No Value";
            suit = "No Type";
            val = v;
            if (v == 1)
            {
                stringVal = "Ace";
            }
            else if (v < 11)
            {
                stringVal = $"{v}";
            }
            else if (v == 11)
            {
                stringVal = "Jack";
            }
            else if (v == 12)
            {
                stringVal = "Queen";
            }
            else if (v == 13)
            {
                stringVal = "King";
            }
            cardName = $"{stringVal} of {suit}";
        }
    }
}