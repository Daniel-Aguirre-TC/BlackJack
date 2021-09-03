using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class GameManager
    {
        // still playing will control if the game is playing or not
        static bool stillPlaying = false;
        // roundOver will be turned to true when the current round finishes to allow starting a new round.
        static bool roundOver = false;
        // deck will store the cards that we're using currently.
        static Deck deck;
        // houseHand will store the cards the house currently has.
        public static List<string> houseHand;
        // the current player
        public static Player player;

        // house/player isStaying bools used to control flow and check results when both are staying
        public static bool houseIsStaying = false;
        public static bool playerIsStaying = false;

        public static void StartGame()
        {
            // set stillPlaying to true.
            stillPlaying = true;
            // Create a new deck which will also
            deck = new Deck();
            houseHand = new List<string>();
            GreetPlayer();
            while(stillPlaying)
            {
                // first deal should happen outside of the round
                FirstDeal();
                while (!roundOver)
                {
                    ContinueRound();
                }

                player.DiscardHand();
                houseHand.Clear();

            }



        }


        /// <summary>
        /// Logic for handling a single game of blackjack after the first two cards have been dealt. This method will be looped until a round is over.
        /// </summary>
        static void ContinueRound()
        {
            if(!playerIsStaying)
            {
                PagePrinter.AskHitOrStay();
                InputHandler.MakeMove();
            }

            if(!houseIsStaying)
            {
                if(CalculateHandSum(houseHand) < 17)
                {
                    DealCard(houseHand);
                }
            }

            if(playerIsStaying && houseIsStaying)
            {
                if(CalculateHandSum(player.PullPlayerHand()) >= CalculateHandSum(houseHand))
                {
                    PagePrinter.GameOverMessage(true);
                }               
                else
                {
                    PagePrinter.GameOverMessage(false);
                }
            }
        }

        /// <summary>
        /// Deal cards for first deal. First deal to player, then house, then player, then house.
        /// </summary>
        static void FirstDeal()
        {
            DealCard(player);
            DealCard(houseHand);
            DealCard(player);
            DealCard(houseHand);
        }

        /// <summary>
        /// Deal a new card to players hand.
        /// </summary>
        /// <param name="player"></param>
        public static void DealCard(Player player)
        {
            var newCard = deck.PullCard();
            player.PlaceCardInHand(newCard);
            PagePrinter.DisplayDealtCard(newCard);
            if (CalculateHandSum(player.PullPlayerHand()) > 21)
            {
                PagePrinter.GameOverMessage(false);
            }
        }

        /// <summary>
        /// Deal a new card to provided hand. Intended for using with houseHand.
        /// </summary>
        /// <param name="housesHand"></param>
        static void DealCard(List<string> housesHand)
        {
            housesHand.Add(deck.PullCard());           
            if (CalculateHandSum(housesHand) > 21)
            {
                PagePrinter.GameOverMessage(true);
            }
            //TODO: Display all cards on the table ??? Do I need to ???
        }

        /// <summary>
        /// Greet Player at beginning of game. Also obtain player name and instantiate the player object.
        /// </summary>
        static void GreetPlayer()
        {
            PagePrinter.PrintOpeningMessage();
            PagePrinter.AskForPlayerName();
            player = new Player(Console.ReadLine());
            PagePrinter.ThankforName(player.name);
        }

        /// <summary>
        /// Calculate score based on the value of each card in the hand provided.
        /// </summary>
        /// <param name="handToCheck"></param>
        /// <returns></returns>
        static int CalculateHandSum(List<string> handToCheck)
        {
            int sum = 0;
            foreach (var card in handToCheck)
            {
                switch(card)
                {
                    case string value when value.Contains("A "):
                        //TODO: Add logic for being able to check if player wants 1 or 11 for value
                        sum += 1;
                        break;
                    case string value when value.Contains("2 "):
                        sum += 2;
                        break;
                    case string value when value.Contains("3 "):
                        sum += 3;
                        break;
                    case string value when value.Contains("4 "):
                        sum += 4;
                        break;
                    case string value when value.Contains("5 "):
                        sum += 5;
                        break;
                    case string value when value.Contains("6 "):
                        sum += 6;
                        break;
                    case string value when value.Contains("7 "):
                        sum += 7;
                        break;
                    case string value when value.Contains("8 "):
                        sum += 8;
                        break;
                    case string value when value.Contains("9 "):
                        sum += 9;
                        break;
                    case string value when value.Contains("10") || value.Contains("Q") || value.Contains("J") || value.Contains("K"):
                        sum += 10;
                        break;
                }
            }
            return sum;

        }


    }
}
