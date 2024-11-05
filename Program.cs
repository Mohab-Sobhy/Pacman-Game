using System;

namespace Pacman_Game;

class Program
{
    static void Main(string[] args)
    {
        GameInterface.WelcomePage();
        Console.ReadKey(false);
        GameEngine game = new GameEngine();
        game.start();
    }
}
