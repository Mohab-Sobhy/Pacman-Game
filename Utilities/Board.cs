using System;
using Pacman_Game.Characters;
using Pacman_Game.Objects;

namespace Pacman_Game
{
    internal class Board
    {
        const int numOfGhosts = 2;
        Pacman player;
        Ghost[] ghosts;
        int numOfFood;

        public Board(Pacman playerObj)
        {
            player = playerObj;
            ghosts = new Ghost[numOfGhosts];
            for (int i = 0; i < numOfGhosts; i++)
            {
                ghosts[i] = new Ghost(1, 1);
            }
            numOfFood = Map.NumOfFood;
        }

        public void print()
        {
            int numRows = Map.MapElements.GetLength(0);
            int numCols = Map.MapElements.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int part = 0; part < 3; part++)
                {
                    for (int col = 0; col < numCols; col++)
                    {
                        bool isPrinted = false;

                        if (row == player.Coordinates[1] && col == player.Coordinates[0])
                        {
                            player.print(part);
                            isPrinted = true;
                        }
                        else
                        {
                            for (int i = 0; i < numOfGhosts; i++)
                            {
                                if (row == ghosts[i].Coordinates[1] && col == ghosts[i].Coordinates[0])
                                {
                                    ghosts[i].print(part);
                                    isPrinted = true;
                                    break;
                                }
                            }
                        }

                        if (!isPrinted)
                        {
                            Map.MapElements[row, col].print(part);
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"\x1b[33mScore: {player.Score.Value}\x1b[37m");
        }

        public int NumOfGhost
        {
            get { return numOfGhosts; }
        }

        public Ghost[] Ghosts
        {
            get { return ghosts; }
        }

        public int NumOfFood
        {
            get { return numOfFood; }
            set { numOfFood = value; }
        }


    }
}
