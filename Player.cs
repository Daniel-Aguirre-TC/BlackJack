using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Player
    {

        static int roundsPlayed = 0;
        List<string> hand;
        public string name;
        int score;


        public Player(string Name)
        {
            name = Name;
            hand = new List<string>();

        }

        /// <summary>
        /// return the cards in the players hand as a string array.
        /// </summary>
        /// <returns></returns>
        public string[] PlayersCards()
        {
            return hand.ToArray();
        }

        /// <summary>
        /// Add a new card to the players hand.
        /// </summary>
        /// <param name="cardToAdd"></param>
        public void PlaceCardInHand(string cardToAdd)
        {
            hand.Add(cardToAdd);
        }

        /// <summary>
        /// Clear the players hand.
        /// </summary>
        public void DiscardHand()
        {
            hand.Clear();
        }

        /// <summary>
        /// Increase the static roundsPlayed variable.
        /// </summary>
        public void IncreaseRoundCount()
        {
            roundsPlayed++;
        }

        /// <summary>
        /// Return the current roundsPlayed count.
        /// </summary>
        /// <returns></returns>
        public int CurrentRound()
        {
            return roundsPlayed;
        }

        /// <summary>
        /// Return the players hand.
        /// </summary>
        /// <returns></returns>
        public List<string> PullPlayerHand()
        {
            return hand;
        }

    }
}
