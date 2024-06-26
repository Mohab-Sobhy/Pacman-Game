using System;

namespace Pacman_Game
{
    internal class Space:Cell
    {
        public Space()
        {
            IsWalkable = true;
            Score = 0;
        }
        public override void print(int lineNo)
        {
            switch (lineNo)
            {
                case 0:
                    Console.Write("      ");
                    break;
                case 1:
                    Console.Write("      ");
                    break;
                case 2:
                    Console.Write("      ");
                    break;
            }
        }
    }
}
