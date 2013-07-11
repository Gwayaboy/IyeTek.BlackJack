using System;
using IyeTek.BlackJack.Core.Commands;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.DependencyResolution;

namespace IyeTek.BlackJack.ConsolePresentation
{
    class Program
    {
        private const string HitCardAction = "h";
        private const string PassCardAction = "s";

        static void Main(string[] args)
        {
            ApplicationConfigurator.BuildContainer();
            var cardGame = ApplicationConfigurator.CardGame;
            var commandProcessor = ApplicationConfigurator.CommandProcessor;


            commandProcessor
                .ConfigureCommand<TakeTurnCommand>(HitCardAction)
                .ConfigureCommand<PassTurnCommand>(PassCardAction);

            var dealer = cardGame.Get<ComputerDealer>(); ;
            var player = cardGame.Get<HumanPlayer>();


            string continueCommand;
            do
            {
                Console.Clear();
                cardGame.Reset();

                string playerAction;

              

                ExecutionResult executionResult;
                do
                {

                    DiplayPlayerCards(dealer, player);
                    playerAction = DisplayScoreAndTakePlayerAction(player);
                    executionResult = commandProcessor.Execute(playerAction);


                } while (!string.IsNullOrWhiteSpace(playerAction)
                         && playerAction.ToLower() == "h" && executionResult.IsSuccessful);

                DiplayPlayerCards(dealer, player);
                DisplayPlayerStatus(executionResult);

                continueCommand = DisplayContinueMessage();
            } while (continueCommand.ToLower() == "p");

        }

        private static void DiplayPlayerCards(ComputerDealer dealer, HumanPlayer player)
        {
            Console.Clear();
            DisplayCardsFor(dealer);
            DisplayCardsFor(player);
        }

        private static void DisplayPlayerStatus(ExecutionResult executionResult)
        {
            Console.ResetColor();
            
            foreach (var error in executionResult.Messages)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine("");
        }

       
        private static string DisplayContinueMessage()
        {
            Console.WriteLine("Do you wish the (P)lay again, press any other key to Quit");

            var playerAction = Console.ReadLine();
            Console.WriteLine("");
            return playerAction;
        }

        private static string DisplayScoreAndTakePlayerAction(Player player)
        {
            Console.ResetColor();
            Console.WriteLine("{0} score is {1}, would you like to Take (H)it or (S)tay:",
                              GetPlayerName(player),
                              player.Score);

            var playerAction = Console.ReadLine();
            Console.WriteLine("");
            return playerAction;
        }

        private static void DisplayCardsFor(Player player)
        {
            var prefix = GetPlayerName(player);
            Console.ResetColor();
            Console.WriteLine("{0} cards:", prefix);
            Console.ForegroundColor = ConsoleColor.Yellow;


            foreach (var card in player.Hand.VisibleCards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("");
        }

        private static string GetPlayerName(Player player)
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
            return prefix;
        }
    }
}
