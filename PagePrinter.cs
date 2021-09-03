using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class PagePrinter : TextController
    {

        #region GreetPlayer Messages
        public static void PrintOpeningMessage()
        {
            PrintCenteredVerticalHorizontal(new string[] {
            "Welcome to Red Rain Casino!", "",
            "Today we're going to play Black Jack.", "",
            "Created by Daniel Aguirre. "
            }, true);
            ClearAfterKeyPress();
        }
        public static void AskForPlayerName()
        {
            string[] messages = new string[]
            {
                "It's nice to meet you ...", "",
                "I'm sorry, what did you say your name was?", "",
                "Your Name: "
            };
            PrintCenteredVerticalHorizontal(messages, messages[2].Length);
        }
        public static void ThankforName(string playerName)
        {
            PrintCenteredVerticalHorizontal(new string[]
            {
                $"Nice to meet you, {playerName}!", "",
                "Now lets play some Blackjack!", "",
                "Press any key to begin. "
            }, true);
            ClearAfterKeyPress();
        }
        #endregion

        /// <summary>
        /// Print the house hand and the player hand to the screen.
        /// </summary>
        public static void DrawTable()
        {
            PrintCenteredHorizontal(new string[] {"Dealers Hand: ", "", ""});
            DrawHand(GameManager.houseHand, true);
            SkipLines(2);
            DrawDeck();
            SkipLines(2);
            DrawHand(GameManager.player.PullPlayerHand(), false);
            SkipLines(2);
        }

        /// <summary>
        /// Clear Screen, Skip two lines, Draw the Dealers Hand, Deck, Players Hand, and then Ask the player what they want to do.
        /// </summary>
        public static void AskHitOrStay()
        {
            Console.Clear();
            SkipLines(2);
            DrawTable();
            PrintCenteredHorizontal(new string[] {
                $"{GameManager.player.name}, It's currently your turn.", "",
                "What would you like to do?", "",
                "1) Hit Me!",
                "2) Stand. ", "",
                " 1 or 2 : "
            }, true);

            //TODO: Skip Lines, Draw Table, Ask hit or stay
        }

        /// <summary>
        /// Interpolate all the cards in the houses hand together, and then print to the screen, centered horizontally. True if Dealer to hide first card.
        /// </summary>
        static void DrawHand(List<string> handToDraw, bool hideFirstCard)
        {
            string[] cardsToDraw = new string[14];
            for (int i = 0; i < handToDraw.Count; i++)
            {
                if (i == 0 && hideFirstCard)
                {
                    InterpolateCard(cardsToDraw, DrawCard(handToDraw[i], false));
                }
                else
                {
                    InterpolateCard(cardsToDraw, DrawCard(handToDraw[i]));
                }
            }
            PrintCenteredHorizontal(cardsToDraw, false, true);
        }

        /// <summary>
        /// Draw the deck to the screen.
        /// </summary>
        static void DrawDeck()
        {
            PrintCenteredHorizontal(DrawCard("Deck", true));
        }

        /// <summary>
        /// Interpolate Cards to be wrote into the console side by side.
        /// </summary>
        /// <param name="destinationArray"></param>
        /// <param name="cardToInterpolate"></param>
        static void InterpolateCard(string[] destinationArray, string[] cardToInterpolate)
        {
            for (int i = 0; i < cardToInterpolate.Length; i++)
            {
                
                destinationArray[i] += cardToInterpolate[i] + "  ";
            }
        }

        /// <summary>
        /// If bool is true then will display deck. If false Hide Values (Dealers First Card).
        /// </summary>
        /// <param name="cardString"></param>
        /// <param name="hideValues"></param>
        /// <returns></returns>
        static string[] DrawCard(string cardString, bool deckOrDealer)
        {
            if(!deckOrDealer)
            {
                // dealer card
                return new string[]
                {
                    "_____________ ",
                    "|             |",
                    "|        ???  |",
                    "|             |",
                    "|             |",
                    "|             |",
                    "|      ?      |",
                    "|             |",
                    "|             |",
                    "|             |",
                    "|  ???        |",
                    "|_____________|",
                    "",
                };
            }
            else
            {
                // deck card
                return new string[]
                {
                    " _____________ ",
                    "|             |",
                    "|             |",
                    "|  Daniel's   |",
                    "|     Black   |",
                    "|       Jack  |",
                    "|             |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|   ~ Deck ~  |",
                    "|   ♠ ♣ ♥ ♦   |",
                    "|             |",
                    "|_____________|",
                    "",
                };
            }
        }

        /// <summary>
        /// Return a string array that represents the card passed in.
        /// </summary>
        /// <param name="cardString"></param>
        /// <returns></returns>
        static string[] DrawCard(string cardString)
        {
            char s = ' ';
            var val = cardString;
            if(cardString.Contains("10 "))
            {
                s = cardString[3];
            }
            else
            s = cardString[2];

            return new string[]
            {
            "______________",
            "|             |",
            $"|       {val}  |",
            "|             |",
            "|             |",
            "|             |",
           $"|      {s}      |",
            "|             |",
            "|             |",
            "|             |",
           $"| {val}        |",
            "|_____________|",
            "",
            };
        }

        /// <summary>
        /// Clear screen, display card dealt, then clear screen after key press.
        /// </summary>
        /// <param name="cardToDisplay"></param>
        public static void DisplayDealtCard(string cardToDisplay)
        {
            List<string> card = new List<string>();
            foreach (var line in DrawCard(cardToDisplay))
            {
                card.Add(line);
            }
            card.Add($"You were dealt {cardToDisplay[0]} of {cardToDisplay[2]}!");
            card.Add("   ");
            card.Add("Press any key to continue. ");         
            PrintCenteredVerticalHorizontal(card.ToArray(), true);
            ClearAfterKeyPress();
        }

        /// <summary>
        /// Display message stating that player won if true. State player loss if false.
        /// </summary>
        /// <param name="playerWon"></param>
        public static void GameOverMessage(bool playerWon)
        {
            string youWonMessage = playerWon ? "Great job, you won!" : "You lost... Better Luck Next Time!";
            //TODO: Expand Game Over Message
            PrintCenteredVerticalHorizontal(new string[]
            {
                youWonMessage,"",
                "Would you like to play again?","",
                "Please enter Y/N: ", "",
                " Selection: "
            }, true);
        }


        public static void InvalidSelectionEntered()
        {
            PrintCenteredVerticalHorizontal(new string[]{
                "Invalid selection.", "",
                "Press any key to try again.", ""
            });
            ClearAfterKeyPress();
        }
    }
}
