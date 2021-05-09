using Oczko.Core;
using Oczko.GameEngine;
using System;

namespace Oczko
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            game.WelcomeScreen();         
            game.GetNextCard();
            game.CountPlayerCardsValue(game.PlayerCards);
            game.GetSummary(game.ActualValue, game.PlayerCards, game.Deck);
            var play = game.Continue();
            do
            {
                game.GetNextCard();
                game.CountPlayerCardsValue(game.PlayerCards);
                play = game.CheckEye(game.ActualValue);
                          
                if(play == true)
                {
                    game.GetSummary(game.ActualValue, game.PlayerCards, game.Deck);
                    play = game.Continue(); 
                }
                
            } while (play == true);
        }
    }
}
