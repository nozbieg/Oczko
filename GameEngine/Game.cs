using Oczko.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oczko.GameEngine
{
    public class Game
    {
        public Game()
        {
            Deck = new Deck();
            PlayerCards = new List<Card>();
            ActualValue = 0;
        }

        public IList<Card> PlayerCards { get; set; }
        public Deck Deck { get; set; }

        public int ActualValue { get; set; }

        public void GetNextCard()
        {
            var random = new Random();
            var randomCard = random.Next(Deck.Cards.Count);
            var selectedCard = Deck.Cards.ElementAt(randomCard);
            PlayerCards.Add(selectedCard);
            Deck.Cards.Remove(selectedCard);
        }

        public void CountPlayerCardsValue(IList<Card> playerCards)
        {
            ActualValue = 0;
            foreach (var card in playerCards)
            {
                ActualValue += card.CardValue;
            }
        }

        public bool NextGameQuestion()
        {
            Console.WriteLine();
            Console.WriteLine("Play again? Y\\N");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wrong key pressed. Select again");
                Continue();
                return false;
            }
        }

        public bool CheckEye(int actualValue)
        {
            if (actualValue <= 21)
            {
                return true;
            }
            else return Lost();
        }

        private bool Lost()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("You got " + PlayerCards.LastOrDefault().ToString());
            Console.WriteLine("Your actual card value is over 21");
            Console.WriteLine("Game lose");

            return false;
        }

        public void WelcomeScreen()
        {
            Console.WriteLine("Welcome in 'MiniBlackJack'");
            Console.WriteLine("Press enter to play");
            Console.ReadLine();
        }

        public void GetSummary(int actualValue, IList<Card> playerCards, Deck deck)
        {
            Console.Clear();
            Console.WriteLine("Your actual Card value is: " + actualValue);
            Console.WriteLine("Cards on hand: ");
            foreach (var card in playerCards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("There is " + deck.Cards.Count + " cards left in deck");
            Console.WriteLine("Do you want to get next card? Y\\N");
        }

        public bool Continue()
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if (key.Key == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wrong key pressed. Select again");
                Continue();
                return false;
            }

        }


        public void PlayGame(Game game)
        {
            Console.Clear();
            var nextGame = false;

            game.WelcomeScreen();
            game.GetNextCard();
            game.CountPlayerCardsValue(game.PlayerCards);
            game.GetSummary(game.ActualValue, game.PlayerCards, game.Deck);

            var play = game.Continue();
            do
            {
                if (play) game.GetNextCard();
                game.CountPlayerCardsValue(game.PlayerCards);
                play = game.CheckEye(game.ActualValue);

                if (play == true)
                {
                    game.GetSummary(game.ActualValue, game.PlayerCards, game.Deck);
                    play = game.Continue();
                    if (play == false)
                    {
                        game.CheckLastCard(game);
                        nextGame = game.NextGameQuestion();
                    }
                }
                else
                {
                    nextGame = game.NextGameQuestion();
                }

            } while (play == true);

            if (nextGame == true)
            {
                game = new Game();
                game.PlayGame(game);
            }
        }

        private void CheckLastCard(Game game)
        {
            game.GetNextCard();
            game.ActualValue += PlayerCards.LastOrDefault().CardValue;
            var result = game.CheckLastEye(game.ActualValue, game);
            if (result == false)
            {
                Console.WriteLine("Dealer got " + PlayerCards.LastOrDefault().ToString());

                Console.WriteLine("His Value is " + game.ActualValue + " You lose");
            }
        }

        private bool CheckLastEye(int actualValue, Game game)
        {
            if (actualValue <= 21)
            {
                return false;
            }
            else return Win(game);
        }

        private bool Win(Game game)
        {
            Console.WriteLine("Dealer got " + PlayerCards.LastOrDefault().ToString());
            Console.WriteLine("His Value is " + game.ActualValue);
            Console.WriteLine("Congratulation you won!");
            return true;
        }
    }
}
