using System;

namespace Pacman_Game.Characters
{
    internal class Pacman : Character
    {
        string name;
        Score score;
        public Pacman(int coordinatesX, int coordinatesY, string playerName = "Pacman")
        : base(coordinatesX, coordinatesY)
        {
            name = playerName;
            score = new Score();
        }
        public void eat(Cell food)
        {
            score.increaseScore(food.Score);
        }
        public Score Score
        {
            get { return score; }
            set { score = value; }
        }
        public override void print(int lineNo)
        {
            switch (lineNo)
            {
                case 0:
                    switch (currentDirection)
                    {
                        case Directions.Up:
                            Console.Write("\x1b[43m \u001b[103m \u001b[43m  \x1b[103m \u001b[43m \x1b[40m");
                            break;
                        default:
                            Console.Write("\x1b[43m      \x1b[40m");
                            break;
                    }
                    break;
                case 1:
                    switch (currentDirection)
                    {
                        case Directions.Left:
                            Console.Write("\u001b[103m  \u001b[43m    \x1b[40m");
                            break;
                        case Directions.Right:
                            Console.Write("\u001b[43m    \u001b[103m  \x1b[40m");
                            break;
                        default:
                            Console.Write("\x1b[43m      \x1b[40m");
                            break;
                    }
                    break;
                case 2:
                    switch (currentDirection)
                    {
                        case Directions.Down:
                            Console.Write("\x1b[43m \u001b[103m \u001b[43m  \x1b[103m \u001b[43m \x1b[40m");
                            break;
                        default:
                            Console.Write("\x1b[43m      \x1b[40m");
                            break;

                    }
                    break;
            }
        }
    }
}