using System;
using Humanizer;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;

namespace IyeTek.BlackJack.ConsolePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var fiftyTwoCardsDeck = new BlackJackDeck();
            var continueCommand = "";
            do
            {
                Console.Clear();
                var shoe = new BlackJackShoeService(fiftyTwoCardsDeck);

                var player = new HumanPlayer(shoe,"Franck");
                var dealer = new ComputerDealer(shoe);

                var game = new BlackJackGameService(dealer, new Player[] {player});

                var playerAction = string.Empty;

                DisplayCardsFor(dealer);

                do
                {
                    DisplayCardsFor(player);
                    playerAction = DisplayScoreAndTakePlayerAction(player, playerAction);
                    if (!string.IsNullOrWhiteSpace(playerAction) && playerAction.ToLower() == "h")
                    {
                        player.TakeTurn();
                    }


                } while (player.Status.Is<Playing>() &&
                         !string.IsNullOrWhiteSpace(playerAction)
                         && playerAction.ToLower() == "h");

                if (player.Status.IsNot<Lost>())
                {
                    dealer.TakeTurn();
                    DisplayCardsFor(dealer);
                }
                else
                {
                    DisplayCardsFor(player);
                }
                game.ResolveStatuses();

                DisplayPlayerStatus(player, dealer);

                continueCommand = DisplayContinueMessage();
            } while (continueCommand.ToLower() == "p");

        }

        private static void DisplayPlayerStatus(Player player, Player dealer)
        {
            var playerStatus = string.Empty;
            var playerName = GetPlayerName(player);

            Console.ForegroundColor = ConsoleColor.Green;
            
            if (player.Status.Is<Won>())
            {
                playerStatus = string.Format("{0} has won", playerName);
            }
            else if (player.Status.Is<Tied>())
            {
                playerStatus = string.Format("{0} and {1} are tie", playerName, GetPlayerName(dealer));
            }
            else if (player.Status.Is<Lost>())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                playerStatus = string.Format("{0} has lost", playerName);
            }

            Console.WriteLine("{0}", playerStatus);
            Console.WriteLine("reason: {0}",player.Status.Reason);
            Console.ResetColor();
            Console.WriteLine("");
        }

        private static string GetPlayerName(Player player)
        {
            var playerName = string.Empty;
            if (!string.IsNullOrWhiteSpace(player.Name))
            {
                playerName += "Player " + player.Name;
            }
            else
            {
                playerName = player.GetType().Name.Humanize(LetterCasing.Sentence);
            }
            return playerName;
        }

        private static string DisplayContinueMessage()
        {
            Console.WriteLine("Do you wish the (P)lay again, press any other key to Quit");

            var playerAction = Console.ReadLine();
            Console.WriteLine("");
            return playerAction;
        }

        private static string DisplayScoreAndTakePlayerAction(HumanPlayer player, string playerAction)
        {
            Console.ResetColor();
            Console.WriteLine("Your score is {0}, would you like to Take (H)it or (S)tay:",
                              player.Score);

            playerAction = Console.ReadLine();
            Console.WriteLine("");
            return playerAction;
        }

        private static void DisplayCardsFor(Player player)
        {
            var prefix = "Dealer's";
            if (player is HumanPlayer)
            {
                prefix = "Your";
                if (!string.IsNullOrWhiteSpace(player.Name))
                {
                    prefix = player.Name + "'s";
                }

            }
            Console.ResetColor();
            Console.WriteLine("{0} cards:", prefix);
            Console.ForegroundColor = ConsoleColor.Yellow;


            foreach (var card in player.Hand.VisibleCards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("");
        }
    }
}
