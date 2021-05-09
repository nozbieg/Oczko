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

            game.PlayGame(game);
        }
    }
}
