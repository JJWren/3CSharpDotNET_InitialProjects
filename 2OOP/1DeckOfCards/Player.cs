using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Player
    {
        public string Name;

        public List<Card> Hand;

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>()
            {
                // Empty hand until dealt cards...
            };
        }

        public Card DrawCard(Deck DeckName)
        {
            Card CardToAdd = DeckName.Deal();
            Hand.Add(CardToAdd);
            Console.WriteLine($"{Name} has drawn a card.");

            return CardToAdd;
        }

        public Card DiscardCard(int CardIdx)
        {
            Card DiscardedCard = Hand[CardIdx];
            Hand.Remove(DiscardedCard);

            return DiscardedCard;
        }

        public void LookCheat()
        {
            int count = 0;
            foreach (Card card in Hand)
            {
                Console.WriteLine($"Card {count}: {card.cardName}");
                count++;
            }
        }
    }
}