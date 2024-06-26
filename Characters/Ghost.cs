using System;
using System.Collections.Generic;

namespace Pacman_Game.Characters
{
    internal class Ghost : Character
    {
        private static readonly Random random = new Random();

        public Ghost(int coordinatesX, int coordinatesY)
            : base(coordinatesX, coordinatesY)
        {
            currentDirection = Directions.Down;
        }

        public void randomDirection(bool r, bool l, bool u, bool d)
        {
            bool[] availableDirections = { r, l, u, d }; // r = right, l = left, u = up, d = down

            List<int> validDirections = new List<int>();
            if (r) validDirections.Add(0);
            if (l) validDirections.Add(1);
            if (u) validDirections.Add(2);
            if (d) validDirections.Add(3);

            if (validDirections.Count == 0)
                return;

            int randomNumber = random.Next(0, validDirections.Count);

            switch (validDirections[randomNumber])
            {
                case 0:
                    currentDirection = Directions.Right;
                    break;
                case 1:
                    currentDirection = Directions.Left;
                    break;
                case 2:
                    currentDirection = Directions.Up;
                    break;
                case 3:
                    currentDirection = Directions.Down;
                    break;
            }
        }

        public override void print(int lineNo)
        {
            switch (lineNo)
            {
                case 0:
                    switch (currentDirection)
                    {
                        case Directions.Up:
                            Console.Write("\x1b[45m \x1b[105m \x1b[45m  \x1b[105m \x1b[45m \x1b[40m");
                            break;
                        case Directions.Right:
                            Console.Write("  \x1b[45m    \x1b[40m");
                            break;
                        case Directions.Left:
                            Console.Write("\u001b[45m    \u001b[40m  ");
                            break;
                        case Directions.Down:
                            Console.Write(" \x1b[45m    \x1b[40m ");
                            break;
                    }
                    break;
                case 1:
                    switch (currentDirection)
                    {
                        case Directions.Left:
                            Console.Write("\x1b[105m  \x1b[45m    \x1b[40m");
                            break;
                        case Directions.Right:
                            Console.Write("\x1b[45m    \x1b[105m  \x1b[40m");
                            break;
                        default:
                            Console.Write("\x1b[45m      \x1b[40m");
                            break;
                    }
                    break;
                case 2:
                    switch (currentDirection)
                    {
                        case Directions.Down:
                            Console.Write("\x1b[45m \x1b[105m \x1b[45m  \x1b[105m \x1b[45m \x1b[40m");
                            break;
                        case Directions.Right:
                            Console.Write("  \x1b[45m    \x1b[40m");
                            break;
                        case Directions.Left:
                            Console.Write("\u001b[45m    \u001b[40m  ");
                            break;
                        case Directions.Up:
                            Console.Write(" \x1b[45m    \x1b[40m ");
                            break;
                    }
                    break;
            }
        }
    }
}
