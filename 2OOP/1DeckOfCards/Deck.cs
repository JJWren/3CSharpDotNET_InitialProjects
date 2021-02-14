using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Deck
    {
        public List<Card> Cards;

        public List<Card> DealtCards;

        public int CardCount;

        public Deck()
        {
            Cards = new List<Card>();
            for (int i = 1; i < 14; i++)
            {
                Hearts newHeart = new Hearts(i);
                Cards.Add(newHeart);
                Console.WriteLine($"{newHeart.cardName} has been added to the deck.");

                Diamonds newDiamond = new Diamonds(i);
                Cards.Add(newDiamond);
                Console.WriteLine($"{newDiamond.cardName} has been added to the deck.");

                Clubs newClub = new Clubs(i);
                Cards.Add(newClub);
                Console.WriteLine($"{newClub.cardName} has been added to the deck.");

                Spades newSpades = new Spades(i);
                Cards.Add(newSpades);
                Console.WriteLine($"{newSpades.cardName} has been added to the deck.");
            }

            DealtCards = new List<Card>()
            {
                // No cards dealt as of yet...
            };

            CardCount = Cards.Count;
        }

        public Card Deal()
        {
            // In a new, non-shuffled deck, the topmost card should be a King of Spades
            int TopCard = (Cards.Count - 1);

            Card CardToReturn = Cards[TopCard];

            Cards.Remove(CardToReturn);
            CardCount--;

            return CardToReturn;
        }

        public void Reset()
        {
            Cards.Clear();
            Cards = new List<Card>();
            for (int i = 1; i < 14; i++)
            {
                Hearts newHeart = new Hearts(i);
                Cards.Add(newHeart);
                Console.WriteLine($"{newHeart.cardName} has been added to the deck.");

                Diamonds newDiamond = new Diamonds(i);
                Cards.Add(newDiamond);
                Console.WriteLine($"{newDiamond.cardName} has been added to the deck.");

                Clubs newClub = new Clubs(i);
                Cards.Add(newClub);
                Console.WriteLine($"{newClub.cardName} has been added to the deck.");

                Spades newSpades = new Spades(i);
                Cards.Add(newSpades);
                Console.WriteLine($"{newSpades.cardName} has been added to the deck.");
            }
            CardCount = Cards.Count;
        }

        public void Shuffle()
        {
            Console.WriteLine("Shuffling the deck...");
            // resort List -> Cards
            Random randShuff = new Random();
            int LotsOfShuffles = randShuff.Next(52, 200);
            int shuffCount = 0;
            for (int i = 0; i < LotsOfShuffles; i++)
            {
                shuffCount++;
                Random rand = new Random();
                int randomCardIDX = rand.Next(Cards.Count);
                Card RmvdCard = Deal();
                Cards.Insert(randomCardIDX, RmvdCard);
            }
            Console.WriteLine($"Shuffled {shuffCount} times. Shuffle complete!");
        }

        public void LookCheat()
        {
            int count = 1;
            foreach (Card card in Cards)
            {
                Console.WriteLine($"{count}. {card.cardName}");
                count++;
            }
        }
    }
}