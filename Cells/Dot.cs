using System;

namespace Pacman_Game
{
    internal class Dot : Food
    {
        public Dot()
        {
            IsWalkable = true;
            Score = 10;
        }

        public override void print(int lineNo)
        {
            switch (lineNo)
            {
                case 0:
                    Console.Write("      ");
                    break;
                case 1:
                    Console.Write("  \x1b[47m  \x1b[40m  ");
                    break;
                case 2:
                    Console.Write("      ");
                    break;
            }
        }
    }
}
