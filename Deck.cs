using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Deck
    {
        // base deck to use for reference when populating a deck.
        static readonly string[] baseDeck;

        /// <summary>
        /// Static Constructor will assign the string values for baseDeck.
        /// </summary>
        static Deck()
        {
            baseDeck = new string[]
            {
                "A ♠ ", "2 ♠ ", "3 ♠ ", "4 ♠ ", "5 ♠ ", "6 ♠ ", "7 ♠ ", "8 ♠ ", "9 ♠ ", "10 ♠", "J ♠ ", "Q ♠ ", "K ♠ ",
                "A ♣ ", "2 ♣ ", "3 ♣ ", "4 ♣ ", "5 ♣ ", "6 ♣ ", "7 ♣ ", "8 ♣ ", "9 ♣ ", "10 ♣", "J ♣ ", "Q ♣ ", "K ♣ ",
                "A ♥ ", "2 ♥ ", "3 ♥ ", "4 ♥ ", "5 ♥ ", "6 ♥ ", "7 ♥ ", "8 ♥ ", "9 ♥ ", "10 ♥", "J ♥ ", "Q ♥ ", "K ♥ ",
                "A ♦ ", "2 ♦ ", "3 ♦ ", "4 ♦ ", "5 ♦ ", "6 ♦ ", "7 ♦ ", "8 ♦ ", "9 ♦ ", "10 ♦", "J ♦ ", "Q ♦ ", "K ♦ ",
            };
        }

        /// <summary>
        /// Constructor for creating a new Deck object. Will populate cards into the deck, pulled from baseDeck.
        /// </summary>
        public Deck()
        {
            PopulateDeck();
        }

        // list of strings to represent the deck for an instance of Deck
        List<string> deck = new List<string>();

        /// <summary>
        /// Clear deck in case it isn't empty and then re-add all cards to the deck.
        /// </summary>
        void PopulateDeck()
        {
            // clear deck in case we call this method and the deck is not already empty.
            deck.Clear();
            // add each string value from baseDeck to this instance of deck.

            //TODO: Shuffle deck 6 times
            foreach (var card in baseDeck)
            {
                deck.Add(card);
            }
        }

        /// <summary>
        /// Return a random string representing a card from the deck. Then remove the pulled card from deck List.
        /// If the deck is now empty, then we will repopulate the deck.
        /// </summary>
        /// <returns></returns>
        public string PullCard()
        {
            // random object used to pull a random card.
            var random = new Random();
            var cardToPull = random.Next(0, deck.Count - 1);
            // store the string of card pulled in cardPulled
            string cardPulled = deck[cardToPull];
            // remove the card pulled from this instance of deck
            deck.RemoveAt(cardToPull);
            // if deck is now empty, then repopulate.
            if (deck.Count == 0)
            {
                PopulateDeck();
            }
            // return cardPulled string.
            return cardPulled;
        }

    }
}
