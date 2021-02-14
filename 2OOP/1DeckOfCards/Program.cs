using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck PokerDeck = new Deck();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");

            PokerDeck.Deal();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");
            PokerDeck.Deal();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");
            PokerDeck.Deal();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");
            PokerDeck.Deal();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");

            PokerDeck.Reset();
            Console.WriteLine($"Total cards in deck: {PokerDeck.CardCount}");
            PokerDeck.Shuffle();
            PokerDeck.LookCheat();

            Player Player1 = new Player("Player 1");
            Player1.DrawCard(PokerDeck);
            Player1.LookCheat();
            PokerDeck.LookCheat();
            Player1.DiscardCard(0);
            Player1.LookCheat();
        }
    }
}
