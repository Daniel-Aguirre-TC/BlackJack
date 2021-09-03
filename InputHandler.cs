using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public static class InputHandler
    {

        /// <summary>
        /// Receive input from player and call the next method depending on input.
        /// </summary>
        public static void MakeMove()
        {
            // store input
            var input = Console.ReadLine();


            switch (input.ToLower())
            {
                // hit me cases
                case string Input when Input.Contains("hit"):
                case "1":
                case "h":
                    GameManager.DealCard(GameManager.player);
                    //TODO: Call method for dealing a card to player.
                    break;

                // stand cases
                case string Input when Input.Contains("stand"):
                case "2":
                case "s":
                    GameManager.playerIsStaying = true;
                    break;

                // if invalid selection then tell player they did an invalid selection then reprint askHitorStay then call MakeMove() again.
                default:
                    PagePrinter.AskHitOrStay();
                    MakeMove();
                    break;
            }


        }

    }
}
