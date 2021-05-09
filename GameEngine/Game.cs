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
            foreach(var card in playerCards)
            {
                ActualValue += card.CardValue;
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
            foreach(var card in playerCards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("There is " + deck.Cards.Count + " cards left in deck");
            Console.WriteLine("Do you want to get next card? Y\\N");
        }

        public bool Continue()
        {       
            var key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.Y)
            {
                return true;
            }
            else if(key.Key == ConsoleKey.N)
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



    }
}
