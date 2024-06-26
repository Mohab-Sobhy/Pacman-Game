using System;

namespace Pacman_Game
{
    internal class Wall : Cell
    {
        public Wall()
        {
            IsWalkable = false;
            Score = 0;
        }
        public override void print(int lineNo)
        {
            switch (lineNo)
            {
                case 0:
                    Console.Write("\x1b[44m      \x1b[40m");
                    break;
                case 1:
                    Console.Write("\x1b[44m      \x1b[40m");
                    break;
                case 2:
                    Console.Write("\x1b[44m      \x1b[40m");
                    break;
            }
        }
    }
}
